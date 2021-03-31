using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalApplication.Core;
using PortalApplication.Core.Models;
using PortalApplication.Infrastructure.DataAccess;

namespace PortalApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;

        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            userRegisterDto.FirstName = userRegisterDto.FirstName.ToLower();
            userRegisterDto.LastName = userRegisterDto.LastName.ToLower();
            
            if (await _repo.UserExists(userRegisterDto.Email)) {
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
        
    }
}