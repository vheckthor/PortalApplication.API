using Microsoft.AspNetCore.Mvc;
using PortalApplication.Core.Dtos;
using PortalApplication.Core.Services.Interfaces;
using PortalApplication.Infrastructure.DataAccess;
using System.Threading.Tasks;

namespace PortalApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        private readonly IContactFormRepository _repo;
        private readonly IFileLogger _logger;

        public ContactFormController(IContactFormRepository repo, IFileLogger logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateForm(ContactFormDto form)
        {
           var sent = await _repo.AddFormDetails(new Core.Models.ContactFormModel
                    {
                        SenderEmail = form.SenderEmail,
                        SenderName = form.SenderName,
                        SenderPhone = form.SenderPhone,
                        Message = form.Message
                    });
            if (sent)
            {
                return Ok("Request Successful");
            }

            return BadRequest("Unable to process your request");
        } 
    }
}
