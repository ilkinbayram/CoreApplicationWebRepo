using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.SocialMedia;
using Core.Entities.Dtos.TeacherSocialMedia;
using Core.Resources.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;



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
        public IFormFile CaptionFile { get; set; }
        public string CaptionSource { get; set; }
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

        public string ProfessionNameKey { get; set; }
        public string ProfessionNameTranslateAZE { get; set; }
        public string ProfessionNameTranslateTUR { get; set; }
        public string ProfessionNameTranslateRUS { get; set; }
        public string ProfessionNameTranslateENG { get; set; }
        public string ProfessionDescriptionKey { get; set; }
        public string ProfessionDescriptionTranslateAZE { get; set; }
        public string ProfessionDescriptionTranslateTUR { get; set; }
        public string ProfessionDescriptionTranslateENG { get; set; }
        public string ProfessionDescriptionTranslateRUS { get; set; }
        public DateTime? StartProfessionCareer { get; set; }
        public ProfessionDegree ProfessionDegree { get; set; }

        public string CompanyNameKey { get; set; }
        public string CompanyNameTranslateAZE { get; set; }
        public string CompanyNameTranslateRUS { get; set; }
        public string CompanyNameTranslateENG { get; set; }
        public string CompanyNameTranslateTUR { get; set; }
        public string JobDescriptionKey { get; set; }
        public string JobDescriptionTranslateAZE { get; set; }
        public string JobDescriptionTranslateTUR { get; set; }
        public string JobDescriptionTranslateENG { get; set; }
        public string JobDescriptionTranslateRUS { get; set; }

        public List<SelectListItem> GenderSelectList { get; set; }
        public List<SelectListItem> ProfessionDegreeSelectList { get; set; }

        public virtual List<CreateManagementTeacherSocialMediaDto> TeacherSocialMedias { get; set; }

        public List<GetSocialMediaDto> SocialMedias { get; set; }
    }

}
