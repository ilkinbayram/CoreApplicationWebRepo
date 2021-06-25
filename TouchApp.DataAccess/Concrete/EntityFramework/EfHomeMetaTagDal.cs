using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfHomeMetaTagDal : EfEntityRepositoryBase<HomeMetaTag, ApplicationDbContext>, IHomeMetaTagDal
    {
        private readonly DbContextOptions _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().Options;
        public EfHomeMetaTagDal(ApplicationDbContext context) : base(context)
        {
        }

        public HomeMetaTag GetItemWithInclude(Expression<Func<HomeMetaTag, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;

            return Context.HomeMetaTags.Include(x => x.HomeMetaTagLanguages).ThenInclude(x => x.Language)
                .Include(x => x.HomeMetaTagGalleries).FirstOrDefault(filter);
        }

        public IEnumerable<HomeMetaTag> GetAllItemsWithInclude(Expression<Func<HomeMetaTag, bool>> filter = null)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            var response = filter == null ?
                Context.HomeMetaTags.AsNoTracking().Include(x => x.HomeMetaTagLanguages).Include(x => x.HomeMetaTagGalleries) :
                Context.HomeMetaTags.AsNoTracking().Include(x => x.HomeMetaTagLanguages).Include(x => x.HomeMetaTagGalleries).Where(filter);
            return response.ToList();
        }
    }
}
