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
    public class EfMediaDal : EfEntityRepositoryBase<Media, ApplicationDbContext>, IMediaDal
    {
        public EfMediaDal(ApplicationDbContext context) : base(context)
        {
        }

        public List<Media> GetAllWithRelations(Expression<Func<Media, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return filter == null ?
                Context.Medias.Include(x => x.SharingTypeMedias).ThenInclude(x => x.Media).Include(x => x.SharingTypeMedias).ThenInclude(x => x.SharingType).ToList() :
                Context.Medias.Include(x => x.SharingTypeMedias).ThenInclude(x => x.Media).Where(filter).ToList();
        }

        public Media GetWithRelations(Expression<Func<Media, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return Context.Medias.Include(x => x.SharingTypeMedias).ThenInclude(x => x.Media).Include(x => x.SharingTypeMedias).ThenInclude(x => x.SharingType).FirstOrDefault(filter);
        }
    }
}
