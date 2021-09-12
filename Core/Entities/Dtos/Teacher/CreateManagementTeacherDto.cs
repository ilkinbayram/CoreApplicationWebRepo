using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Profession;
using Core.Entities.Dtos.SocialMedia;
using Core.Resources.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Entities.Dtos.Teacher
{
    public class CreateManagementTeacherDto : BaseDto
    {
        public CreateManagementTeacherDto()
        {
            ModelType = ProjectModelType.Teacher;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumberPrefix { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile PreviewMovieFile { get; set; }
        public string PreviewMoviePath { get; set; }
        public IFormFile IconSourceFile { get; set; }
        public string IconSource { get; set; }
        public string SecurityToken { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public decimal? Rate { get; set; }
        public int? RateCount { get; set; }
        public string BiographyKey { get; set; }
        public string BiographyTranslateAZE { get; set; }
        public string BiographyTranslateTUR { get; set; }
        public string BiographyTranslateRUS { get; set; }
        public string BiographyTranslateENG { get; set; }
        public IFormFile ProfilePhotoFile { get; set; }
        public string ProfilePhotoPath { get; set; }
        public IFormFile WallpaperFile { get; set; }
        public string WallpaperPath { get; set; }

        public long ProfessionId { get; set; }

        public List<SelectListItem> CurrentProfessionList { get; set; }

        public GetProfessionDto Profession { get; set; }
        public List<GetSocialMediaDto> SocialMedias { get; set; }
    }

}
