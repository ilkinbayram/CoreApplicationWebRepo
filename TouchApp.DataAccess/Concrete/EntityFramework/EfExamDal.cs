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
    public class EfExamDal : EfEntityRepositoryBase<Exam, ApplicationDbContext>, IExamDal
    {
        public EfExamDal(ApplicationDbContext context) : base(context)
        {
        }

        public List<Exam> GetAllWithRelations(Expression<Func<Exam, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return filter == null ?
                Context.Exams.Include(x => x.ExamQuestions).ThenInclude(x => x.Exam).Include(x => x.ExamQuestions).ThenInclude(x => x.Question).ToList() :
                Context.Exams.Include(x => x.ExamQuestions).ThenInclude(x => x.Exam).Include(x => x.ExamQuestions).ThenInclude(x => x.Question).Where(filter).ToList();
        }

        public Exam GetWithRelations(Expression<Func<Exam, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return Context.Exams.Include(x => x.ExamQuestions).ThenInclude(x => x.Exam).Include(x => x.ExamQuestions).ThenInclude(x => x.Question).FirstOrDefault(filter);
        }
    }
}
