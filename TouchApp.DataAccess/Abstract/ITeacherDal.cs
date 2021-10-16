using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TouchApp.DataAccess.Abstract
{
    public interface ITeacherDal : IEntityRepository<Teacher>, IEntityQueryableRepository<Teacher>
    {
        List<Teacher> GetAllWithRelations(Expression<Func<Teacher, bool>> filter);
        Teacher GetWithRelations(Expression<Func<Teacher, bool>> filter);

    }
}
