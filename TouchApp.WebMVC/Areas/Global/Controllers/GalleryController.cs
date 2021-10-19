using Core.Entities.Dtos.SharingType;
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
    public class GalleryController : Controller
    {
        private readonly IMediaService _mediaService;

        public GalleryController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpGet]
        public async Task<IActionResult> Touch()
        {
            var viewModel = new GalleryViewModel();
            viewModel.Medias = _mediaService.GetDtoList().Data;

            foreach (var item in viewModel.Medias)
            {
                if (viewModel.SharingTypes == null)
                    viewModel.SharingTypes = new List<GetSharingTypeDto>();

                item.SharingTypeMedias.Select(x => x.SharingType).ToList().ForEach(x =>
                {
                    if (!viewModel.SharingTypes.Any(p=>p.AbriveatureClass==x.AbriveatureClass))
                    {
                        viewModel.SharingTypes.Add(x);
                    }
                });
            }

            return View(viewModel);
        }
    }
}
