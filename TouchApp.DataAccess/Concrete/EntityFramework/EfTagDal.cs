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
    public class EfTagDal : EfEntityRepositoryBase<Tag, ApplicationDbContext>, ITagDal
    {
        public EfTagDal(ApplicationDbContext context) : base(context)
        {
        }

        public List<Tag> GetAllWithRelations(Expression<Func<Tag, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return filter == null ?
                Context.Tags.
                Include(x => x.TagBlogs).ThenInclude(x => x.Tag).
                Include(x => x.TagBlogs).ThenInclude(x => x.Blog).ToList() :
                Context.Tags.
                Include(x => x.TagBlogs).ThenInclude(x => x.Tag).
                Include(x => x.TagBlogs).ThenInclude(x => x.Blog).Where(filter).ToList();
        }

        public Tag GetWithRelations(Expression<Func<Tag, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return Context.Tags.
                Include(x => x.TagBlogs).ThenInclude(x => x.Tag).
                Include(x => x.TagBlogs).ThenInclude(x => x.Blog).FirstOrDefault(filter);
        }
    }
}
