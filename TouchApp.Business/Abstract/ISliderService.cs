using Core.Entities.Concrete;
using Core.Entities.Dtos.Slider;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        Task<IDataResult<List<GetSliderDto>>> GetDtoListAsync(Expression<Func<Slider, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetSliderDto>> GetDtoAsync(Expression<Func<Slider, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<Slider> sliders);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<Slider> sliders);
        Task<IDataResult<List<Slider>>> GetListAsync(Expression<Func<Slider, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<Slider> sliders);
        Task<IDataResult<int>> UpdateAsync(Slider slider);
        Task<IDataResult<Slider>> GetAsync(Expression<Func<Slider, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(Slider slider);
    }
}
