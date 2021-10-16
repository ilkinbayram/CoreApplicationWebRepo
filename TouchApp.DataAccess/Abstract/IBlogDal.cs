using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TouchApp.DataAccess.Abstract
{
    public interface IBlogDal : IEntityRepository<Blog>, IEntityQueryableRepository<Blog>
    {
        List<Blog> GetAllWithRelations(Expression<Func<Blog, bool>> filter = null);
        Blog GetWithRelations(Expression<Func<Blog, bool>> filter = null);
    }
}
