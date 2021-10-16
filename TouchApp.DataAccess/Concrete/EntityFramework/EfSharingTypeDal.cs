using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfSharingTypeDal : EfEntityRepositoryBase<SharingType, ApplicationDbContext>, ISharingTypeDal
    {
        public EfSharingTypeDal(ApplicationDbContext context) : base(context)
        {
        }

        public List<SharingType> GetAllWithRelations(Expression<Func<SharingType, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return filter == null ?
                Context.SharingTypes.
                Include(x => x.SharingTypeMedias).ThenInclude(x => x.SharingType).
                Include(x => x.SharingTypeMedias).ThenInclude(x => x.Media).ToList() :
                Context.SharingTypes.
                Include(x => x.SharingTypeMedias).ThenInclude(x => x.SharingType).
                Include(x => x.SharingTypeMedias).ThenInclude(x => x.Media).Where(filter).ToList();
        }

        public SharingType GetWithRelations(Expression<Func<SharingType, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return Context.SharingTypes.
                Include(x => x.SharingTypeMedias).ThenInclude(x => x.SharingType).
                Include(x => x.SharingTypeMedias).ThenInclude(x => x.Media).FirstOrDefault(filter);
        }
    }
}
