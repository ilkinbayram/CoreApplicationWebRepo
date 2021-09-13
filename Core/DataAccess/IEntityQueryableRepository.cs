using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Core.Entities;


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
