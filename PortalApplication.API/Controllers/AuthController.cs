using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PortalApplication.Core;
using PortalApplication.Core.Dtos;
using PortalApplication.Core.Models;
using PortalApplication.Infrastructure.DataAccess;

namespace PortalApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            userRegisterDto.FirstName = userRegisterDto.FirstName.ToLower();
            userRegisterDto.LastName = userRegisterDto.LastName.ToLower();

            if (await _repo.UserExists(userRegisterDto.Email))
            {
                return BadRequest("User already exists");
            }

            var userToBeCreated = new UserModel
            {
                Email = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
            };

            var createdUser = await _repo.Register(userToBeCreated, userRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var userFromDB = await _repo.Login(userLoginDto.Email, userLoginDto.Password);

            if (userFromDB == null)
            {
                return Unauthorized();
            }
            
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromDB.Id.ToString()),
                new Claim(ClaimTypes.Surname, userFromDB.LastName),
                new Claim(ClaimTypes.Name, userFromDB.FirstName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            
            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
            
        }

    }
}