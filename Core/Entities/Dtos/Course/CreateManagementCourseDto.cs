using System;
using System.Collections.Generic;
using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.ProfessionCourseCategory;
using Core.Entities.Dtos.TeacherCourse;
using Core.Resources.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Entities.Dtos.Course
{
    public class CreateManagementCourseDto : BaseDto
    {
        public CreateManagementCourseDto()
        {
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
        public byte MinTotalMonths { get; set; }
        public byte MaxTotalMonths { get; set; }
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
        public string OverViewHtmlRawKey { get; set; }
        public string OverViewHtmlRawTranslateAZE { get; set; }
        public string OverViewHtmlRawTranslateTUR { get; set; }
        public string OverViewHtmlRawTranslateENG { get; set; }
        public string OverViewHtmlRawTranslateRUS { get; set; }
        public DateTime PublishDate { get; set; }
        public List<SelectListItem> CurrentListProfessionCourseCategoryIds { get; set; }
        public long ProfessionCourseCategoryId { get; set; }

        public List<CreateManagementTeacherCourseDto> TeacherCourses { get; set; }
        public GetProfessionCourseCategoryDto ProfessionCourseCategory { get; set; }
    }
}
