using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
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
        public int DeleteByStatus(TEntity entity)
        {
            var deletedEntity = Context.Entry(entity);
            deletedEntity.State = EntityState.Modified;
            return Context.SaveChanges();
        }

        public void DeleteByStatusBeforeCommit(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public void AddBeforeCommit(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void UpdateBeforeCommit(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public int DeletePermanently(TEntity entity)
        {
            var deletedEntity = Context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            return Context.SaveChanges();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return Context.Set<TEntity>().SingleOrDefault(filter);
        }

        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
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

        public virtual int Add(IEnumerable<TEntity> entities)
        {
            Context.Set<IEnumerable<TEntity>>().Add(entities);
            return Context.SaveChanges();
        }


        public virtual int Update(IEnumerable<TEntity> entities)
        {
            var updatedEntities = Context.Entry(entities);
            updatedEntities.State = EntityState.Modified;
            return Context.SaveChanges();
        }

        public int DeletePermanently(IEnumerable<TEntity> entities)
        {
            var deletedEntities = Context.Entry(entities);
            deletedEntities.State = EntityState.Deleted;
            return Context.SaveChanges();
        }

        public int DeleteByStatus(IEnumerable<TEntity> entities)
        {
            var deletedEntities = Context.Entry(entities);
            deletedEntities.State = EntityState.Modified;
            return Context.SaveChanges();
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
        public TEntity GetById(long id)
        {

            var result = Context.Set<TEntity>().Find(id);
            return result;
        }

        public IList<TEntity> GetAll()
        {
            Context.ChangeTracker.LazyLoadingEnabled = true;
          return  Context.Set<TEntity>().ToList();

        }
    }
}
