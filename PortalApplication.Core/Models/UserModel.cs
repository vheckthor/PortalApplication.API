using System;

namespace PortalApplication.Core.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] HashPassword { get; set; }
        public byte[] SaltPassword { get; set; }
        public bool IsVerified { get; set; }
        public DateTime AccountCreationDate { get; set; }

        public UserModel()
        {
            AccountCreationDate = DateTime.Now;
        }
    }
}