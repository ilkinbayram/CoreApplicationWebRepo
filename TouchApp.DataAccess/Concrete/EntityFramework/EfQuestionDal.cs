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
    public class EfQuestionDal : EfEntityRepositoryBase<Question, ApplicationDbContext>, IQuestionDal
    {
        public EfQuestionDal(ApplicationDbContext context) : base(context)
        {
        }

        public List<Question> GetAllWithRelations(Expression<Func<Question, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return filter == null ?
                Context.Questions.
                Include(x => x.ExamQuestions).ThenInclude(x => x.Question).
                Include(x => x.QuestionResults).ThenInclude(x => x.Question).
                Include(x => x.ExamQuestions).ThenInclude(x => x.Exam).
                Include(x => x.QuestionResults).ThenInclude(x => x.ResultExam).ToList() :
                Context.Questions.
                Include(x => x.ExamQuestions).ThenInclude(x => x.Question).
                Include(x => x.QuestionResults).ThenInclude(x => x.Question).
                Include(x => x.ExamQuestions).ThenInclude(x => x.Exam).
                Include(x => x.QuestionResults).ThenInclude(x => x.ResultExam).Where(filter).ToList();
        }

        public Question GetWithRelations(Expression<Func<Question, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return Context.Questions.
                Include(x => x.ExamQuestions).ThenInclude(x => x.Question).
                Include(x => x.QuestionResults).ThenInclude(x => x.Question).
                Include(x => x.ExamQuestions).ThenInclude(x => x.Exam).
                Include(x => x.QuestionResults).ThenInclude(x => x.ResultExam).FirstOrDefault(filter);
        }
    }
}
