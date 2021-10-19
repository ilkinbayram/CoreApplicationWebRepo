using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.ProfessionCourseCategory;
using Core.Entities.Dtos.TeacherCourse;
using Core.Resources.Enums;
using Core.Entities.Dtos.Language;
using Core.Utilities.UsableModel;

namespace Core.Entities.Dtos.Course
{
    public class CreateManagementCourseDto : BaseDto
    {
        public CreateManagementCourseDto()
        {
            TeacherCourses = new List<CreateManagementTeacherCourseDto>();
            ResponseMessages = new List<AlertResult>();
            ModelType = ProjectModelType.Course;
        }

        public string UniqueToken { get; set; }
        public IFormFile CaptionImageFile { get; set; }
        public string CaptionImageSource { get; set; }
        public string TitleKey { get; set; }
        public string TitleTranslateAZE { get; set; }
        public string TitleTranslateRUS { get; set; }
        public string TitleTranslateTUR { get; set; }
        public string TitleTranslateENG { get; set; }
        public string DescriptionKey { get; set; }
        public string DescriptionTranslateAZE { get; set; }
        public string DescriptionTranslateRUS { get; set; }
        public string DescriptionTranslateENG { get; set; }
        public string DescriptionTranslateTUR { get; set; }
        public string PreviewDescKey { get; set; }
        public string PreviewDescTranslateAZE { get; set; }
        public string PreviewDescTranslateRUS { get; set; }
        public string PreviewDescTranslateENG { get; set; }
        public string PreviewDescTranslateTUR { get; set; }
        public string CourseInfoHtmlMaintenanceKey { get; set; }
        public string CourseInfoHtmlMaintenanceTranslateAZE { get; set; }
        public string CourseInfoHtmlMaintenanceTranslateRUS { get; set; }
        public string CourseInfoHtmlMaintenanceTranslateENG { get; set; }
        public string CourseInfoHtmlMaintenanceTranslateTUR { get; set; }
        public byte TotalMonths { get; set; }
        public short TotalHours { get; set; }
        public decimal PricePerMonth { get; set; }
        public string ScheduleHtmlRawKey { get; set; }
        public string ScheduleHtmlRawTranslateAZE { get; set; }
        public string ScheduleHtmlRawTranslateTUR { get; set; }
        public string ScheduleHtmlRawTranslateENG { get; set; }
        public string ScheduleHtmlRawTranslateRUS { get; set; }
        public string ContentHtmlRawKey { get; set; }
        public string ContentHtmlRawTranslateAZE { get; set; }
        public string ContentHtmlRawTranslateTUR { get; set; }
        public string ContentHtmlRawTranslateENG { get; set; }
        public string ContentHtmlRawTranslateRUS { get; set; }

        public List<SelectListItem> CurrentListTeachers { get; set; }
        public List<SelectListItem> CurrentListProfessionCourseCategoryIds { get; set; }
        public List<SelectListItem> CurrentListLanguageIds { get; set; }

        public long ProfessionCourseCategoryId { get; set; }
        public long LanguageId { get; set; }
        public long TeacherId { get; set; }

        public List<CreateManagementTeacherCourseDto> TeacherCourses { get; set; }
        public GetProfessionCourseCategoryDto ProfessionCourseCategory { get; set; }
        public GetLanguageDto Language { get; set; }

        public List<AlertResult> ResponseMessages { get; set; }
    }
}
