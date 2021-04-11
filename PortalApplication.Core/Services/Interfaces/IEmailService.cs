using System.Threading.Tasks;

namespace PortalApplication.Core.Services.Interfaces
{
    public interface IEmailService
    {
        public void Send(int Id, string Email, string FirstName);
    }
}