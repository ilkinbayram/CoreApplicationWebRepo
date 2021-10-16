using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TouchApp.DataAccess.Abstract
{
    public interface ISharingTypeDal : IEntityRepository<SharingType>, IEntityQueryableRepository<SharingType>
    {
        List<SharingType> GetAllWithRelations(Expression<Func<SharingType, bool>> filter);
        SharingType GetWithRelations(Expression<Func<SharingType, bool>> filter);

    }
}
