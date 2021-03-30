using System.Threading.Tasks;
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
        public Task<UserModel> Login(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserModel> Register(UserModel user, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UserExists(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}