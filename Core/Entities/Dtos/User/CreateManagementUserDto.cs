using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.SocialMedia;
using Core.Entities.Dtos.UserSocialMedia;
using Core.Resources.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Core.Entities.Dtos.User
{
    public class CreateManagementUserDto : BaseDto
    {
        public CreateManagementUserDto()
        {
            ModelType = ProjectModelType.User;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IFormFile ProfilePhotoFile { get; set; }
        public string ProfilePhotoPath { get; set; }
        public IFormFile WallpaperFile { get; set; }
        public string WallpaperPath { get; set; }
        public string PhoneNumberPrefix { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public string BiographyKey { get; set; }
        public string BiographyTranslateAZE { get; set; }
        public string BiographyTranslateTUR { get; set; }
        public string BiographyTranslateENG { get; set; }
        public string BiographyTranslateRUS { get; set; }

        public List<SelectListItem> GenderSelectList { get; set; }

        public virtual List<CreateManagementUserSocialMediaDto> UserSocialMedias { get; set; }
        public List<GetSocialMediaDto> SocialMedias { get; set; }
    }
}
