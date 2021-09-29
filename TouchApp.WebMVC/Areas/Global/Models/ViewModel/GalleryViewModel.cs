using Core.Entities.Dtos.Media;
using Core.Entities.Dtos.SharingType;
using System.Collections.Generic;

namespace TouchApp.WebMVC.Areas.Global.Models.ViewModel
{
    public class GalleryViewModel
    {
        public List<GetMediaDto> Medias { get; set; }
        public List<GetSharingTypeDto> SharingTypes { get; set; }
    }
}
