
using PortalApplication.Core.Data;

namespace PortalApplication.Core.Controllers
{
    public class AuthController
    {
        private readonly IAuthRepository _repo;
        // private readonly IConfiguration _config;
        
        // public AuthController(IAuthRepository repo, IConfiguration config)
        public AuthController()
        {
            
        }
        
        // [HttpPost("register")]
        public string Register(UserRegisterDto userRegisterDto) 
        {
            return "testing";
        }
    }
}