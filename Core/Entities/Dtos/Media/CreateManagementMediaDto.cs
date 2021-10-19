using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.SharingTypeMedia;
using Core.Resources.Enums;
using Core.Utilities.UsableModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Core.Entities.Dtos.Media
{
    public class CreateManagementMediaDto : BaseDto
    {
        public CreateManagementMediaDto()
        {
            SharingTypeMedias = new List<CreateManagementSharingTypeMediaDto>();
            ResponseMessages = new List<AlertResult>();
            ModelType = ProjectModelType.Media;
        }
        public string UniqueParentToken { get; set; }
        public string Source { get; set; }

        public IFormFile SourceFile { get; set; }
        public MediaType MediaType { get; set; }

        public List<SelectListItem> MediaTypes { get; set; }
        public List<SelectListItem> GivenDataesForSharingTypeIds { get; set; }


        public List<long> SelectedSharingTypes { get; set; }


        public List<CreateManagementSharingTypeMediaDto> SharingTypeMedias { get; set; }
        public List<AlertResult> ResponseMessages { get; set; }
    }
}
