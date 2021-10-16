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
    public class EfBlogDal : EfEntityRepositoryBase<Blog, ApplicationDbContext>, IBlogDal
    {
        public EfBlogDal(ApplicationDbContext context) : base(context)
        {
        }

        public List<Blog> GetAllWithRelations(Expression<Func<Blog, bool>> filter = null)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return filter == null ?
                Context.Blogs.Include(x => x.TagBlogs).ThenInclude(x => x.Blog).Include(x=>x.TagBlogs).ThenInclude(x=>x.Tag).ToList() :
                Context.Blogs.Include(x => x.TagBlogs).ThenInclude(x => x.Blog).Include(x => x.TagBlogs).ThenInclude(x => x.Tag).Where(filter).ToList();
        }

        public Blog GetWithRelations(Expression<Func<Blog, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return Context.Blogs.Include(x => x.TagBlogs).ThenInclude(x => x.Blog).Include(x => x.TagBlogs).ThenInclude(x => x.Tag).FirstOrDefault(filter);
        }
    }
}
