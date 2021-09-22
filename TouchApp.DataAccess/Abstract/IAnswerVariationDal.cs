﻿using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IAnswerVariationDal : IEntityRepository<AnswerVariation>, IEntityQueryableRepository<AnswerVariation>
    {
    }
}
