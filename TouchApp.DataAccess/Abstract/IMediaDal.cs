using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TouchApp.DataAccess.Abstract
{
    public interface IMediaDal : IEntityRepository<Media>, IEntityQueryableRepository<Media>
    {
        List<Media> GetAllWithRelations(Expression<Func<Media, bool>> filter);
        Media GetWithRelations(Expression<Func<Media, bool>> filter);

    }
}
