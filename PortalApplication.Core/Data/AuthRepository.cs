using System.Threading.Tasks;
using PortalApplication.Core.Models;

namespace PortalApplication.Core.Data
{
    public class AuthRepository: DataContext
    {
        private readonly DataContext _context;
        
        public AuthRepository(DataContext context)
        {
            _context= context;
        }
        public User Register(User user, string password)
        {
            return user;
        }
    }
}