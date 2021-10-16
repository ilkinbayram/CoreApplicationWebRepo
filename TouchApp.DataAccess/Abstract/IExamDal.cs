using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TouchApp.DataAccess.Abstract
{
    public interface IExamDal : IEntityRepository<Exam>, IEntityQueryableRepository<Exam>
    {
        List<Exam> GetAllWithRelations(Expression<Func<Exam, bool>> filter);
        Exam GetWithRelations(Expression<Func<Exam, bool>> filter);
    }
}
