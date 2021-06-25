using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryFeatureService
    {
        IDataResult<IEnumerable<CategoryFeature>> GetList(Expression<Func<CategoryFeature, bool>> filter = null);
        IDataResult<CategoryFeature> Get(Expression<Func<CategoryFeature, bool>> filter);
        IDataResult<int> Add(CategoryFeature categoryFeature);
        IDataResult<int> Update(CategoryFeature categoryFeature);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<CategoryFeature> categoryFeatures);
        IDataResult<int> UpdateList(IEnumerable<CategoryFeature> categoryFeatures);
        IDataResult<int> DeletePermanentlyList(IEnumerable<CategoryFeature> categoryFeatures);
        IDataResult<int> DeleteByStatusList(IEnumerable<CategoryFeature> categoryFeatures);
    }
}
