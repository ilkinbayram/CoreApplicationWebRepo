using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface IRoutingService
    {
        IDataResult<IEnumerable<Routing>> GetList(Expression<Func<Routing, bool>> filter = null);
        IDataResult<Routing> Get(Expression<Func<Routing, bool>> filter);
        IDataResult<int> Add(Routing routing);
        IDataResult<int> Update(Routing routing);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<Routing> routings);
        IDataResult<int> UpdateList(IEnumerable<Routing> routings);
        IDataResult<int> DeletePermanentlyList(IEnumerable<Routing> routings);
        IDataResult<int> DeleteByStatusList(IEnumerable<Routing> routings);
    }
}
