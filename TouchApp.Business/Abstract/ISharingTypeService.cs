using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ISharingTypeService
    {
        IDataResult<IEnumerable<SharingType>> GetList(Expression<Func<SharingType, bool>> filter = null);
        IDataResult<SharingType> Get(Expression<Func<SharingType, bool>> filter);
        IDataResult<int> Add(SharingType sharingType);
        IDataResult<int> Update(SharingType sharingType);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<SharingType> sharingTypes);
        IDataResult<int> UpdateList(IEnumerable<SharingType> sharingTypes);
        IDataResult<int> DeletePermanentlyList(IEnumerable<SharingType> sharingTypes);
        IDataResult<int> DeleteByStatusList(IEnumerable<SharingType> sharingTypes);
    }
}
