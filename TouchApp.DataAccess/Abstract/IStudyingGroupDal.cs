using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TouchApp.DataAccess.Abstract
{
    public interface IStudyingGroupDal : IEntityRepository<StudyingGroup>, IEntityQueryableRepository<StudyingGroup>
    {
        List<StudyingGroup> GetAllWithRelations(Expression<Func<StudyingGroup, bool>> filter);
        StudyingGroup GetWithRelations(Expression<Func<StudyingGroup, bool>> filter);

    }
}
