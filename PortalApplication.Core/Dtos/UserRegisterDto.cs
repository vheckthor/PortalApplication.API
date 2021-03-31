using System.ComponentModel.DataAnnotations;

namespace PortalApplication.Core
{
    public class UserRegisterDto
    {   
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Password must be atleast 8 characters")]
        public string Password { get; set; }
    }
}