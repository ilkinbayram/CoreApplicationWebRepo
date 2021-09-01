using Core.Entities.Concrete;
using Core.Entities.Dtos.Blog;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface IBlogService
    {
        IDataResult<List<GetBlogDto>> GetDtoList(Func<GetBlogDto, bool> filter = null, int takeCount = 2000);
        IDataResult<GetBlogDto> GetDto(Func<GetBlogDto, bool> filter);
        IDataResult<List<Blog>> GetList(Expression<Func<Blog, bool>> filter = null);
        IDataResult<Blog> Get(Expression<Func<Blog, bool>> filter);
        IDataResult<int> Add(Blog blog);
        IDataResult<int> Update(Blog blog);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Blog> blogs);
        IDataResult<int> UpdateList(List<Blog> blogs);
        IDataResult<int> DeletePermanentlyList(List<Blog> blogs);
        IDataResult<int> DeleteByStatusList(List<Blog> blogs);
    }
}
