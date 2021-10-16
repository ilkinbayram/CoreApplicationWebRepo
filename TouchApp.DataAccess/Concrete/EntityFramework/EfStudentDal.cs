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
    public class EfStudentDal : EfEntityRepositoryBase<Student, ApplicationDbContext>, IStudentDal
    {
        public EfStudentDal(ApplicationDbContext context) : base(context)
        {
        }

        public List<Student> GetAllWithRelations(Expression<Func<Student, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return filter == null ?
                Context.Students.
                Include(x => x.StudentOperationClaims).ThenInclude(x => x.Student).
                Include(x => x.StudentStudyingGroups).ThenInclude(x => x.Student).
                Include(x => x.ResultExams).ThenInclude(x => x.Student).
                Include(x => x.StudentOperationClaims).ThenInclude(x => x.OperationClaim).
                Include(x => x.StudentStudyingGroups).ThenInclude(x => x.StudyingGroup).
                Include(x => x.ResultExams).ThenInclude(x => x.Exam).ToList() :
                Context.Students.
                Include(x => x.StudentOperationClaims).ThenInclude(x => x.Student).
                Include(x => x.StudentStudyingGroups).ThenInclude(x => x.Student).
                Include(x => x.ResultExams).ThenInclude(x => x.Student).
                Include(x => x.StudentOperationClaims).ThenInclude(x => x.OperationClaim).
                Include(x => x.StudentStudyingGroups).ThenInclude(x => x.StudyingGroup).
                Include(x => x.ResultExams).ThenInclude(x => x.Exam).Where(filter).ToList();
        }

        public Student GetWithRelations(Expression<Func<Student, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return Context.Students.
                Include(x => x.StudentOperationClaims).ThenInclude(x => x.Student).
                Include(x => x.StudentStudyingGroups).ThenInclude(x => x.Student).
                Include(x => x.ResultExams).ThenInclude(x => x.Student).
                Include(x => x.StudentOperationClaims).ThenInclude(x => x.OperationClaim).
                Include(x => x.StudentStudyingGroups).ThenInclude(x => x.StudyingGroup).
                Include(x => x.ResultExams).ThenInclude(x => x.Exam).FirstOrDefault(filter);
        }
    }
}
