using System.Threading.Tasks;
using PortalApplication.Core.Models;

namespace PortalApplication.Core.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
    }
}