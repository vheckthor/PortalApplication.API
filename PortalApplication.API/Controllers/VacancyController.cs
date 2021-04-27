using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalApplication.Core.Dtos;
using PortalApplication.Core.Models;
using PortalApplication.Core.Services.Interfaces;
using PortalApplication.Infrastructure.DataAccess;

namespace PortalApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyRepository _repo;
        private readonly IFileLogger _logger;
        public VacancyController(IVacancyRepository repo, IFileLogger logger)
        {
            _logger = logger;
            _repo = repo;

        }
        
        [HttpPost]
        public async Task<IActionResult> CreateVacancy(VacancyDto data)
        {
            var listOfDescription = new List<Descriptions>();
            var listOfRequirements = new List<Requirements>();
            var vacancyUniqueId = Guid.NewGuid();
            if(data.Requirement.Length !=0 || data.Description.Length != 0)
            {
                foreach(var item in data.Description)
                {
                    listOfDescription.Add(new Descriptions
                    {
                        JobDescriptions = item,
                        VacancyUniqueId = vacancyUniqueId
                    });
                }

                foreach(var item in data.Requirement)
                {
                    listOfRequirements.Add(new Requirements
                    {
                        JobRequirements = item,
                        VacancyUniqueId = vacancyUniqueId
                    });
                }
            }
            var sent = await _repo.CreateVacancy(new Core.Models.VacancyModel
                        {
                            JobId = data.JobId,
                            CompanyName = data.CompanyName,
                            Position = data.Position,
                            Requirement = listOfRequirements,
                            Description = listOfDescription,
                            VacancyUniqueId = vacancyUniqueId
                        });
            if (sent)
            {
                return Ok("Request Successful");
            }
            
            return BadRequest("Unable to process your request");
        }
    }
}