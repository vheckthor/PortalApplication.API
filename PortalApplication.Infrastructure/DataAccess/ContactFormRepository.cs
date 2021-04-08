using Microsoft.EntityFrameworkCore;
using PortalApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalApplication.Infrastructure.DataAccess
{
    public class ContactFormRepository : IContactFormRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactFormRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddFormDetails(ContactFormModel forms)
        {
            _ = await _dbContext.AddAsync(forms);
            var saved = await _dbContext.SaveChangesAsync() > 0;
            return saved;
        }

        public async Task<ContactFormModel> GetAForm(int id)
        {
            var result = await _dbContext.ContactForms
                              .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
