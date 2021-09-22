using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.CourseComment;
using Core.Entities.Dtos.Language;
using Core.Entities.Dtos.ProfessionCourseCategory;
using Core.Entities.Dtos.StudyingGroup;
using Core.Entities.Dtos.TeacherCourse;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;


namespace Core.Entities.Dtos.Course
{
    public class GetCourseDto : BaseDto
    {
        public GetCourseDto()
        {
            ModelType = ProjectModelType.Course;
        }
        public string UniqueToken { get; set; }
        public string CaptionImageSource { get; set; }
        public string TitleKey { get; set; }
        public string DescriptionKey { get; set; }
        public byte MinTotalMonths { get; set; }
        public byte MaxTotalMonths { get; set; }
        public short TotalHours { get; set; }
        public decimal PricePerMonth { get; set; }
        public string ScheduleHtmlRawKey { get; set; }
        public string ContentHtmlRawKey { get; set; }
        public string OverViewHtmlRawKey { get; set; }
        public DateTime PublishDate { get; set; }

        public long ProfessionCourseCategoryId { get; set; }
        public long LanguageId { get; set; }


        public List<GetStudyingGroupDto> StudyingGroups { get; set; }
        public List<GetTeacherCourseDto> TeacherCourses { get; set; }
        public List<GetCourseCommentDto> CourseComments { get; set; }
        public GetProfessionCourseCategoryDto ProfessionCourseCategory { get; set; }
        public GetLanguageDto Language { get; set; }
    }
}
