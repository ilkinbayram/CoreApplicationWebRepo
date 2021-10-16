using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TouchApp.DataAccess.Abstract
{
    public interface ITagDal : IEntityRepository<Tag>, IEntityQueryableRepository<Tag>
    {
        List<Tag> GetAllWithRelations(Expression<Func<Tag, bool>> filter);
        Tag GetWithRelations(Expression<Func<Tag, bool>> filter);

    }
}
