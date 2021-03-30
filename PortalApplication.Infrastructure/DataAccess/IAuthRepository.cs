using System.Threading.Tasks;
using PortalApplication.Core.Models;

namespace PortalApplication.Infrastructure.DataAccess
{
    public interface IAuthRepository
    {
         Task<UserModel> Register(UserModel user, string password);
         Task<UserModel> Login(string email, string password);
         Task<bool> UserExists(string email);
         
    }
}