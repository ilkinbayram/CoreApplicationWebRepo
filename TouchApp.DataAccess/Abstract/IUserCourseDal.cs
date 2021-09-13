﻿using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IUserCourseDal : IEntityRepository<UserCourse>, IEntityQueryableRepository<UserCourse>
    {
    }
}
