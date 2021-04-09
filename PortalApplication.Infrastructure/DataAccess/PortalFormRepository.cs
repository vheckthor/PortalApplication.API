using Microsoft.EntityFrameworkCore;
using PortalApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PortalApplication.Infrastructure.DataAccess
{
    public class PortalFormRepository : IPortalFormRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PortalFormRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddPortalForm(PortalFormData forms)
        {

            _ = await _dbContext.AddAsync(forms);
            var saved = await _dbContext.SaveChangesAsync() > 0;
            return saved;
        }

        public async Task<PortalFormData> GetPortalForm(Guid id)
        {
            var result = await _dbContext.PortalFormDatas
                              .FirstOrDefaultAsync(x => x.UniqueIdentifier == id);

            return result;
        }

        public async Task<List<PortalFormData>> GetAllPortalForm<T>(Expression<Func<PortalFormData, bool>> predicate, Expression<Func<PortalFormData, T>> order)
        {
            List<PortalFormData> response;
            if (order == null)
            {
                var listToReturn1 = Task.Run(() => (from x in _dbContext.PortalFormDatas.Where(predicate.Compile())
                                                    select x).ToList());
                response = await listToReturn1;
            }
            else
            {
                var listToReturn = Task.Run(() => (from x in _dbContext.PortalFormDatas.Where(predicate.Compile())
                                                   select x).OrderByDescending(order.Compile()).ToList());
                response = await listToReturn;
            }

            return response;
        }



        public async Task<bool> CheckDuplicate(Expression<Func<PortalFormData, bool>> predicate)
        {
            var response  = await _dbContext.PortalFormDatas.FindAsync(predicate.Compile());

            return response !=null;
        }
    }
}
