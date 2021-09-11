﻿using Core.Entities.Dtos.Base;
using Core.Resources.Enums;
using Microsoft.AspNetCore.Http;

namespace Core.Entities.Dtos.SocialMedia
{
    public class CreateManagementSocialMediaDto : BaseDto
    {
        public CreateManagementSocialMediaDto()
        {
            ModelType = ProjectModelType.SocialMedia;
        }

        public string NameSocial { get; set; }
        public string Uri { get; set; }
        public IFormFile IconSourceFile { get; set; }
        public string IconSource { get; set; }
    }
}