using System.ComponentModel.DataAnnotations;

namespace PortalApplication.Core
{
    public class UserRegisterDto
    {   
        [Required]
        public string Email { get; set; }
        
        [Required]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Passowed must be atleast 8 characters")]
        public string Password { get; set; }
    }
}