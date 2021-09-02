using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityQueryableRepository<T> 
        where T: class, IEntity, new() 
    {
        IQueryable<T> GetAllAsQueryable();
        Task<IQueryable<T>> GetAllAsQueryableAsync();
        Task<IQueryable<T>> GetAllAsQueryableAsync(Expression<Func<T, bool>> filter);
    }
}
