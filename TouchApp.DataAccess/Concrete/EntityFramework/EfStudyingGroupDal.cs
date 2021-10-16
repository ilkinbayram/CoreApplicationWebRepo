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
    public class EfStudyingGroupDal : EfEntityRepositoryBase<StudyingGroup, ApplicationDbContext>, IStudyingGroupDal
    {
        public EfStudyingGroupDal(ApplicationDbContext context) : base(context)
        {
        }

        public List<StudyingGroup> GetAllWithRelations(Expression<Func<StudyingGroup, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return filter == null ?
                Context.StudyingGroups.
                Include(x => x.StudentStudyingGroups).ThenInclude(x => x.StudyingGroup).
                Include(x => x.StudentStudyingGroups).ThenInclude(x => x.Student).ToList() :
                Context.StudyingGroups.
                Include(x => x.StudentStudyingGroups).ThenInclude(x => x.StudyingGroup).
                Include(x => x.StudentStudyingGroups).ThenInclude(x => x.Student).Where(filter).ToList();
        }

        public StudyingGroup GetWithRelations(Expression<Func<StudyingGroup, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return Context.StudyingGroups.
                Include(x => x.StudentStudyingGroups).ThenInclude(x => x.StudyingGroup).
                Include(x => x.StudentStudyingGroups).ThenInclude(x => x.Student).FirstOrDefault(filter);
        }
    }
}
