using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Dtos.Blog;
using Core.Entities.Dtos.BlogCategory;
using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.Tag;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.WebMVC.Areas.Global.Models.ViewModel;
using TouchApp.WebMVC.Filters;

namespace TouchApp.WebMVC.Areas.Global.Controllers
{
    [Area("Global")]
    [LocalizationFilter]
    public class BlogController : Controller
    {
        private IBlogService _blogService;
        private IBlogCategoryService _blogCategoryService;
        private ICourseService _courseService;
        private ITagService _tagService;
        private IMapper _mapper;

        public BlogController(IBlogService blogService,
                              IBlogCategoryService blogCategoryService,
                              IMapper mapper,
                              ICourseService courseService,
                              ITagService tagService)
        {
            _blogService = blogService;
            _blogCategoryService = blogCategoryService;
            _mapper = mapper;
            _courseService = courseService;
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> Touch()
        {
            var viewModel = new AllBlogsViewModel();
            viewModel.AllBlogs = _blogService.GetListDto().Data;
            viewModel.BlogCategories = _blogCategoryService.GetListDto().Data;
            viewModel.RecentCourses = _courseService.GetDtoList().Data.OrderByDescending(x => x.Created_at).Take(4).ToList();
            viewModel.Tags = _tagService.GetListDto().Data;

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> FilterByTagName(long id)
        {
            var viewModel = new AllBlogsViewModel();
            viewModel.AllBlogs = _blogService.GetFilteredBlogsByTagId(id).Data;
            viewModel.BlogCategories = _blogCategoryService.GetListDto().Data;
            viewModel.RecentCourses = _courseService.GetDtoList().Data.OrderByDescending(x => x.Created_at).Take(4).ToList();
            viewModel.Tags = _tagService.GetListDto().Data;

            return View("Touch", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> FilterByBlogCategoryId(long id)
        {
            var viewModel = new AllBlogsViewModel();
            viewModel.AllBlogs = _blogService.GetFilteredBlogsByBlogCategoryId(id).Data;
            viewModel.BlogCategories = _blogCategoryService.GetListDto().Data;
            viewModel.RecentCourses = _courseService.GetDtoList().Data.OrderByDescending(x => x.Created_at).Take(4).ToList();
            viewModel.Tags = _tagService.GetListDto().Data;

            return View("Touch", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrent(long id)
        {
            var viewModel = new BlogViewModel();
            viewModel.CurrentBlog = _blogService.GetDto(x => x.Id == id).Data;
            viewModel.BlogCategories = _blogCategoryService.GetListDto().Data;
            viewModel.RecentCourses = _courseService.GetDtoList().Data.OrderByDescending(x=>x.Created_at).Take(4).ToList();
            viewModel.Tags = _tagService.GetListDto().Data;

            if (viewModel.CurrentBlog!=null)
            {
                viewModel.RelatedBlogs = _blogService.GetRelatedBlogsByBlogCategoryId(viewModel.CurrentBlog.BlogCategoryId, viewModel.CurrentBlog.Id).Data;
            }
            
            return View(viewModel);
        }
    }
}
