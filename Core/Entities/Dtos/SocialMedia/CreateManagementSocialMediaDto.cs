using Microsoft.AspNetCore.Http;

using Core.Entities.Dtos.Base;
using Core.Resources.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Core.Utilities.UsableModel;

namespace Core.Entities.Dtos.SocialMedia
{
    public class CreateManagementSocialMediaDto : BaseDto
    {
        public CreateManagementSocialMediaDto()
        {
            ModelType = ProjectModelType.SocialMedia;
            ResponseMessages = new List<AlertResult>();
        }

        public SocialMediaType SocialMediaType { get; set; }
        public string NameSocial { get; set; }
        public string Uri { get; set; }
        public IFormFile IconSourceFile { get; set; }
        public string IconSource { get; set; }
        public string IconHtml { get; set; }

        public List<SelectListItem> SocialMediaTypeList { get; set; }

        public List<AlertResult> ResponseMessages { get; set; }
    }
}
