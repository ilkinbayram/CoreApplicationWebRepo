using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IHomeMetaTagDal : IEntityRepository<HomeMetaTag>
    {
        HomeMetaTag GetItemWithInclude(Expression<Func<HomeMetaTag, bool>> filter);
        IEnumerable<HomeMetaTag> GetAllItemsWithInclude(Expression<Func<HomeMetaTag, bool>> filter = null);
    }
}
