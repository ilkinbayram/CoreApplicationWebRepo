﻿using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IQuestionVariationDal : IEntityRepository<QuestionVariation>, IEntityQueryableRepository<QuestionVariation>
    {
    }
}