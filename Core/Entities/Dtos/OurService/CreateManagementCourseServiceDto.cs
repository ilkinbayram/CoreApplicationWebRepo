﻿using Core.Entities.Dtos.Base;
using Core.Resources.Enums;
using Microsoft.AspNetCore.Http;

namespace Core.Entities.Dtos.OurService
{
    public class CreateManagementCourseServiceDto : BaseDto
    {
        public CreateManagementCourseServiceDto()
        {
            ModelType = ProjectModelType.CourseService;
        }

        public string TitleKey { get; set; }
        public string TitleTranslateAZE { get; set; }
        public string TitleTranslateRUS { get; set; }
        public string TitleTranslateENG { get; set; }
        public string TitleTranslateTUR { get; set; }
        public string DescriptionKey { get; set; }
        public string DescriptionTranslateAZE { get; set; }
        public string DescriptionTranslateRUS { get; set; }
        public string DescriptionTranslateENG { get; set; }
        public string DescriptionTranslateTUR { get; set; }
        public string UniqueToken { get; set; }
        public IFormFile IconSourceFile { get; set; }
        public string IconSource { get; set; }
    }
}