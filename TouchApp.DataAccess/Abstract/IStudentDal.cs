using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TouchApp.DataAccess.Abstract
{
    public interface IStudentDal : IEntityRepository<Student>, IEntityQueryableRepository<Student>
    {
        List<Student> GetAllWithRelations(Expression<Func<Student, bool>> filter);
        Student GetWithRelations(Expression<Func<Student, bool>> filter);

    }
}
