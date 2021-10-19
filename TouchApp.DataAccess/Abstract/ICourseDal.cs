using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TouchApp.DataAccess.Abstract
{
    public interface ICourseDal : IEntityRepository<Course>, IEntityQueryableRepository<Course>
    {
        List<Course> GetAllWithRelations(Expression<Func<Course, bool>> filter = null);
        Course GetWithRelations(Expression<Func<Course, bool>> filter);
    }
}
