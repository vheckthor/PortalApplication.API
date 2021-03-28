using System.Threading.Tasks;
using PortalApplication.Core.Models;

namespace PortalApplication.Core.Data
{
    public interface IAuthRepository
    {
         Task<UserModel> Register(UserModel user, string password);
    }
}