namespace PortalApplication.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string Email { get; set; }
        public byte[] HashPassword { get; set; }
        public byte[] SaltPassword { get; set; }
    }
}