using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfResultExamDal : EfEntityRepositoryBase<ResultExam, ApplicationDbContext>, IResultExamDal
    {
        public EfResultExamDal(ApplicationDbContext context) : base(context)
        {
        }

        public List<ResultExam> GetAllWithRelations(Expression<Func<ResultExam, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return filter == null ?
                Context.ResultExams.
                Include(x => x.QuestionResults).ThenInclude(x => x.ResultExam).
                Include(x => x.QuestionResults).ThenInclude(x => x.Question).ToList() :
                Context.ResultExams.
                Include(x => x.QuestionResults).ThenInclude(x => x.ResultExam).
                Include(x => x.QuestionResults).ThenInclude(x => x.Question).Where(filter).ToList();
        }

        public ResultExam GetWithRelations(Expression<Func<ResultExam, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return Context.ResultExams.
                Include(x => x.QuestionResults).ThenInclude(x => x.ResultExam).
                Include(x => x.QuestionResults).ThenInclude(x => x.Question).FirstOrDefault(filter);
        }
    }
}
