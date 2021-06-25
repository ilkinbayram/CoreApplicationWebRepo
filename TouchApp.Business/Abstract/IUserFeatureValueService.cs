using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IUserFeatureValueService
    {
        IDataResult<IEnumerable<UserFeatureValue>> GetList(Expression<Func<UserFeatureValue, bool>> filter = null);
        IDataResult<UserFeatureValue> Get(Expression<Func<UserFeatureValue, bool>> filter);
        IDataResult<int> Add(UserFeatureValue userFeatureValue);
        IDataResult<int> Update(UserFeatureValue userFeatureValue);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<UserFeatureValue> userFeatureValues);
        IDataResult<int> UpdateList(IEnumerable<UserFeatureValue> userFeatureValues);
        IDataResult<int> DeletePermanentlyList(IEnumerable<UserFeatureValue> userFeatureValues);
        IDataResult<int> DeleteByStatusList(IEnumerable<UserFeatureValue> userFeatureValues);
    }
}
