using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using PortalApplication.Core.Models;
using PortalApplication.Core.Dtos;

namespace PortalApplication.Infrastructure.DataAccess
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VacancyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateVacancy(VacancyModel data)
        {
            _ = await _dbContext.AddAsync(data);
            var saved = await _dbContext.SaveChangesAsync() > 0;
            return saved;
        }

        public async Task<VacancyModel[]> GetAllVacancies()
        {
            var result = await _dbContext.Vacancy.ToArrayAsync();
            return result;
        }
        

        public async Task<VacancyModel> GetVacancyById(int id)
        {
            var user = await _dbContext.Vacancy.FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }
    }
}