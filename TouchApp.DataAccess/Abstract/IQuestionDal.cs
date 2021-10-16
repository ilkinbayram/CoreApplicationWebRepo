using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TouchApp.DataAccess.Abstract
{
    public interface IQuestionDal : IEntityRepository<Question>, IEntityQueryableRepository<Question>
    {
        List<Question> GetAllWithRelations(Expression<Func<Question, bool>> filter);
        Question GetWithRelations(Expression<Func<Question, bool>> filter);

    }
}
