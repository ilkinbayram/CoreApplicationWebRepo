using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TouchApp.DataAccess.Abstract
{
    public interface ISocialMediaDal : IEntityRepository<SocialMedia>, IEntityQueryableRepository<SocialMedia>
    {
        List<SocialMedia> GetAllWithRelations(Expression<Func<SocialMedia, bool>> filter);
        SocialMedia GetWithRelations(Expression<Func<SocialMedia, bool>> filter);

    }
}
