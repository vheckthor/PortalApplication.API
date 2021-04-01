using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortalApplication.Core.Models;

namespace PortalApplication.Infrastructure.DataAccess
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserModel> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            
            if (user == null) {
                return null;
            }
            
            if(!DoesPasswordHashMatch(password, user.SaltPassword, user.HashPassword)){
                return null;
            }
            
            return user;
        }

        private bool DoesPasswordHashMatch(string password, byte[] saltPassword, byte[] hashPassword)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(saltPassword)) 
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if(computeHash[i] != hashPassword[i]){
                        return false;
                    }
                }
            }
            return true;
        }

        public async Task<UserModel> Register(UserModel user, string password)
        {
            byte[] hashPassword, saltPassword;
            
            // passing hashPassword and saltPassword as reference to this method
            CreatePasswordHash(password, out hashPassword, out saltPassword);
            
            user.HashPassword = hashPassword;
            user.SaltPassword = saltPassword;
            
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] hashPassword, out byte[] saltPassword)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) 
            {
                saltPassword = hmac.Key;
                hashPassword = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users.AnyAsync(x => x.Email == email)) {
                return true;
            }
            
            return false;
        }
    }
}