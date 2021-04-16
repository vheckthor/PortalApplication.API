using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalApplication.Core.Dtos;
using PortalApplication.Core.Models;
using PortalApplication.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PortalApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortalFormController : ControllerBase
    {
        private readonly IPortalFormRepository _repo;

        public PortalFormController(IPortalFormRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitForm(PortalFormDataDtos data)
        {
            Expression<Func<PortalFormData, bool>> query = (PortalFormData x) =>
            (x.Fullname.Trim().ToLower() == data.Fullname.Trim().ToLower() 
            || x.Email.Trim().ToLower() == data.Email.Trim().ToLower())
            && x.JobID == data.JobID;

            var exist = await _repo.CheckDuplicate(query);

            if (exist)
            {
                return BadRequest("You have submitted an application for this job before");
            }
            var identifier = Guid.NewGuid();
            string cvlink = default;

            //yet to implement cloudinary.
            var body = new PortalFormData
            {
                RelevantSkills = data.RelevantSkills.Trim(),
                ClassOfDegree = data.ClassOfDegree.Trim(),
                Email = data.Email.Trim(),
                CurrentEmployer = data.CurrentEmployer.Trim(),
                DOB = data.DOB,
                CurrentRole = data.CurrentRole.Trim(),
                Fullname = data.Fullname.Trim(),
                PhoneNumber = data.PhoneNumber.Trim(),
                ProfessionalCertificate = data.ProfessionalCertificate.Trim(),
                TetInstitution = data.TetInstitution.Trim(),
                Role = data.Role.Trim(),
                WhyRole = data.WhyRole.Trim(),
                YearofExperience = Convert.ToString(data.YearofExperience),
                UniqueIdentifier = identifier,
                CVLink = cvlink
            };
            var response = await _repo.AddPortalForm(body);
            if (response)
            {
                return Created("Request Successful", new { });
            }
            return BadRequest("Unable to process your request");
        }
    }
}
