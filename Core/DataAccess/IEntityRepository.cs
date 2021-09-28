using System;
using System.Collections.Generic;
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
        List<T> GetList(Expression<Func<T, bool>> filter=null);
        int Add(T entity);
        int Update(T entity);
        int Add(List<T> entities);
        int Update(List<T> entities);
        int DeletePermanently(T entity);
        int DeleteByStatus(T entity);
        int DeletePermanently(List<T> entities);
        int DeleteByStatus(List<T> entities);
        void RemoveRange(List<T> entities);

        void DeleteByStatusBeforeCommit(T entity);
        void AddBeforeCommit(T entity);
        void UpdateBeforeCommit(T entity);

        int Commit();

        Task<int> AddAsync(T entity);
        Task<int> CommitAsync();
        Task<int> DeleteByStatusAsync(T entity);
        Task AddBeforeCommitAsync(T entity);
        Task<int> DeletePermanentlyAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
        Task<int> UpdateAsync(T entity);
        Task<int> AddAsync(List<T> entities);
        Task<int> UpdateAndSaveAsync(List<T> entities);
        Task<int> DeletePermanentlyAsync(List<T> entities);
        Task<int> DeleteByStatusAsync(List<T> entities);
        Task<T> GetByIdAsync(long id);
    }
}
