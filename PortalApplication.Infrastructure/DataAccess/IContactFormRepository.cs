using PortalApplication.Core.Models;
using System.Threading.Tasks;

namespace PortalApplication.Infrastructure.DataAccess
{
    public interface IContactFormRepository
    {
        Task<bool> AddFormDetails(ContactFormModel forms);
        Task<ContactFormModel> GetAForm(int id);
    }
}