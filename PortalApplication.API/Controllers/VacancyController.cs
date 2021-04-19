using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalApplication.Core.Dtos;
using PortalApplication.Core.Services.Interfaces;
using PortalApplication.Infrastructure.DataAccess;

namespace PortalApplication.API.Controllers
{
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyRepository _repo;
        private readonly IFileLogger _logger;
        public VacancyController(IVacancyRepository repo, IFileLogger logger)
        {
            _logger = logger;
            _repo = repo;

        }
        
        public async Task<IActionResult> CreateVacancy(VacancyDto data)
        {
            var sent = await _repo.CreateVacancy(new Core.Models.VacancyModel
                        {
                            JobId = data.JobId,
                            CompanyName = data.CompanyName,
                            Position = data.Position,
                            Description = data.Description,
                            Requirement = data.Requirement
                        });
            if (sent)
            {
                return Ok("Request Successful");
            }
            
            return BadRequest("Unable to process your request");
        }
    }
}