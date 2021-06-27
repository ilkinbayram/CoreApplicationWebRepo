using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ISectionService
    {
        IDataResult<IEnumerable<Section>> GetList(Expression<Func<Section, bool>> filter = null);
        IDataResult<Section> Get(Expression<Func<Section, bool>> filter);
        IDataResult<int> Add(Section section);
        IDataResult<int> Update(Section section);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<Section> sections);
        IDataResult<int> UpdateList(IEnumerable<Section> sections);
        IDataResult<int> DeletePermanentlyList(IEnumerable<Section> sections);
        IDataResult<int> DeleteByStatusList(IEnumerable<Section> sections);
    }
}
