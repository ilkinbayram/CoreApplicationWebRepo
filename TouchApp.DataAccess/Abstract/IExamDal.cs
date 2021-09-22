﻿using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IExamDal : IEntityRepository<Exam>, IEntityQueryableRepository<Exam>
    {
    }
}