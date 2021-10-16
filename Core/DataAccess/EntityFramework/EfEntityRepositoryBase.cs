using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Core.Entities;


namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>, IEntityQueryableRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext
    {
        protected readonly TContext Context;

        public EfEntityRepositoryBase(TContext applicationContext)
        {
            Context = applicationContext;
        }


        public virtual int Add(TEntity entity)
        {
            //var addedEntity = Context.Entry(entity);
            //addedEntity.State = EntityState.Added;
            Context.Set<TEntity>().Add(entity);

            return Context.SaveChanges();
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        /// <summary>
        /// Delete method must change the 'IsActive' status to the 'false' with its relations
        /// </summary>
        /// <param name="entity">The entity which will be deleted</param>
        /// <returns></returns>
        public virtual int DeleteByStatus(TEntity entity)
        {
            var deletedEntity = Context.Entry(entity);
            deletedEntity.State = EntityState.Modified;
            return Context.SaveChanges();
        }

        public virtual void DeleteByStatusBeforeCommit(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public virtual void AddBeforeCommit(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual void UpdateBeforeCommit(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public virtual int DeletePermanently(TEntity entity)
        {
            var deletedEntity = Context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            return Context.SaveChanges();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return Context.Set<TEntity>().FirstOrDefault(filter);
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? Context.Set<TEntity>().ToList()
                : Context.Set<TEntity>().Where(filter).ToList();
        }

        public virtual int Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            //var updatedEntity = Context.Entry(entity);
            //updatedEntity.State = EntityState.Modified;
            return Context.SaveChanges();
        }

        public virtual int Add(List<TEntity> entities)
        {
            Context.Set<List<TEntity>>().Add(entities);
            return Context.SaveChanges();
        }


        public virtual int Update(List<TEntity> entities)
        {
            var updatedEntities = Context.Entry(entities);
            updatedEntities.State = EntityState.Modified;
            return Context.SaveChanges();
        }

        public virtual int DeletePermanently(List<TEntity> entities)
        {
            var deletedEntities = Context.Entry(entities);
            deletedEntities.State = EntityState.Deleted;
            return Context.SaveChanges();
        }

        public virtual int DeleteByStatus(List<TEntity> entities)
        {
            var deletedEntities = Context.Entry(entities);
            deletedEntities.State = EntityState.Modified;
            return Context.SaveChanges();
        }
        public virtual void RemoveRange(List<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
        public virtual TEntity GetById(long id)
        {

            var result = Context.Set<TEntity>().Find(id);
            return result;
        }

        public virtual IList<TEntity> GetAll()
        {
            Context.ChangeTracker.LazyLoadingEnabled = true;
          return  Context.Set<TEntity>().ToList();

        }

        public async virtual Task<IQueryable<TEntity>> GetAllAsQueryableAsync(Expression<Func<TEntity, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = true;
            var result = Task.FromResult(Context.Set<TEntity>().Where(filter));
            return await result;
        }

        public async virtual Task<IQueryable<TEntity>> GetAllAsQueryableAsync()
        {
            Context.ChangeTracker.LazyLoadingEnabled = true;
            var result = Task.FromResult(Context.Set<TEntity>());
            return await result;
        }

        public async virtual Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            Context.ChangeTracker.LazyLoadingEnabled = true;
            var result = expression != null
                ? Context.Set<TEntity>().Where(expression).ToListAsync()
                : Context.Set<TEntity>().ToListAsync();
            return await result;
        }

        public virtual IQueryable<TEntity> GetAllAsQueryable(Expression<Func<TEntity, bool>> expression = null)
        {
            Context.ChangeTracker.LazyLoadingEnabled = true;
            var result = expression == null ?
                Context.Set<TEntity>() :
                Context.Set<TEntity>().Where(expression);
            return result;
        }

        public async virtual Task<int> AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);

            return await Context.SaveChangesAsync();
        }

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete method must change the 'IsActive' status to the 'false' with its relations
        /// </summary>
        /// <param name="entity">The entity which will be deleted</param>
        /// <returns></returns>
        public async virtual Task<int> DeleteByStatusAsync(TEntity entity)
        {
            var deletedEntity = Context.Entry(entity);
            deletedEntity.State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }

        public async virtual Task AddBeforeCommitAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public async virtual Task<int> DeletePermanentlyAsync(TEntity entity)
        {
            var deletedEntity = Context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            return await Context.SaveChangesAsync();
        }

        public async virtual Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async virtual Task<int> UpdateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            return await Context.SaveChangesAsync();
        }

        public async virtual Task<int> AddAsync(List<TEntity> entities)
        {
            await Context.Set<List<TEntity>>().AddAsync(entities);
            return await Context.SaveChangesAsync();
        }


        public async virtual Task<int> UpdateAndSaveAsync(List<TEntity> entities)
        {
            var updatedEntities = Context.Entry(entities);
            updatedEntities.State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }

        public async virtual Task<int> DeletePermanentlyAsync(List<TEntity> entities)
        {
            var deletedEntities = Context.Entry(entities);
            deletedEntities.State = EntityState.Deleted;
            return await Context.SaveChangesAsync();
        }

        public async virtual Task<int> DeleteByStatusAsync(List<TEntity> entities)
        {
            var deletedEntities = Context.Entry(entities);
            deletedEntities.State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }

        public async virtual Task<TEntity> GetByIdAsync(long id)
        {

            var result = Context.Set<TEntity>().FindAsync(id);
            return await result;
        }
    }
}
