using System.Threading.Tasks;
using PortalApplication.Core.Models;

namespace PortalApplication.Infrastructure.DataAccess
{
    public interface IVacancyRepository
    {
        Task<bool> CreateVacancy(VacancyModel data);
        Task<VacancyModel[]> GetAllVacancies();
        Task<VacancyModel> GetVacancyById(int id);
    }
}