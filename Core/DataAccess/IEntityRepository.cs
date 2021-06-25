using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        T GetById(long id);
        IList<T> GetAll();

        T Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetList(Expression<Func<T, bool>> filter=null);
        int Add(T entity);
        int Update(T entity);
        int Add(IEnumerable<T> entities);
        int Update(IEnumerable<T> entities);
        int DeletePermanently(T entity);
        int DeleteByStatus(T entity);
        int DeletePermanently(IEnumerable<T> entities);
        int DeleteByStatus(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);

        void DeleteByStatusBeforeCommit(T entity);
        void AddBeforeCommit(T entity);
        void UpdateBeforeCommit(T entity);

        int Commit();
    }
}
