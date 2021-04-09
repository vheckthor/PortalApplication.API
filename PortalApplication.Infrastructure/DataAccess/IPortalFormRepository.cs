using PortalApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PortalApplication.Infrastructure.DataAccess
{
    public interface IPortalFormRepository
    {
        Task<bool> AddPortalForm(PortalFormData forms);
        Task<List<PortalFormData>> GetAllPortalForm<T>(Expression<Func<PortalFormData, bool>> predicate, Expression<Func<PortalFormData, T>> order);
        Task<PortalFormData> GetPortalForm(Guid id);
        Task<bool> CheckDuplicate(Expression<Func<PortalFormData, bool>> predicate);
    }
}