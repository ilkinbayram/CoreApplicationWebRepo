using Core.Entities.Concrete;
using Core.Entities.Dtos.Slider;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ISliderService
    {
        IDataResult<List<Slider>> GetList(Expression<Func<Slider, bool>> filter = null);
        IDataResult<Slider> Get(Expression<Func<Slider, bool>> filter);
        IDataResult<List<GetSliderDto>> GetDtoList(Func<GetSliderDto, bool> filter = null, int takeCount = 2000);
        IDataResult<GetSliderDto> GetDto(Func<GetSliderDto, bool> filter);
        IDataResult<int> Add(Slider homeMetaTagGallery);
        IDataResult<int> Update(Slider homeMetaTagGallery);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Slider> homeMetaTagGalleries);
        IDataResult<int> UpdateList(List<Slider> homeMetaTagGalleries);
        IDataResult<int> DeletePermanentlyList(List<Slider> homeMetaTagGalleries);
        IDataResult<int> DeleteByStatusList(List<Slider> homeMetaTagGalleries);
    }
}
