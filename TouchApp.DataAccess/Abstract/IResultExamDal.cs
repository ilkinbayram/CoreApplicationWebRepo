using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TouchApp.DataAccess.Abstract
{
    public interface IResultExamDal : IEntityRepository<ResultExam>, IEntityQueryableRepository<ResultExam>
    {
        List<ResultExam> GetAllWithRelations(Expression<Func<ResultExam, bool>> filter);
        ResultExam GetWithRelations(Expression<Func<ResultExam, bool>> filter);

    }
}
