using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfHomeMetaTagDal : EfEntityRepositoryBase<HomeMetaTag, ApplicationDbContext>, IHomeMetaTagDal
    {
        private readonly DbContextOptions _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().Options;
        public EfHomeMetaTagDal(ApplicationDbContext context) : base(context)
        {
        }

        public HomeMetaTag GetItemWithInclude(Expression<Func<HomeMetaTag, bool>> filter)
        {
            return null;
        }

        public IEnumerable<HomeMetaTag> GetAllItemsWithInclude(Expression<Func<HomeMetaTag, bool>> filter = null)
        {
            return null;
        }
    }
}
