using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.TeacherCourse;
using Core.Entities.Dtos.TeacherSocialMedia;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;



namespace Core.Entities.Dtos.Teacher
{
    public class GetTeacherDto : BaseDto
    {
        public GetTeacherDto()
        {
            ModelType = ProjectModelType.Teacher;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumberPrefix { get; set; }
        public string PhoneNumber { get; set; }
        public string PreviewMoviePath { get; set; }
        public string CaptionSource { get; set; }
        public string SecurityToken { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public decimal? Rate { get; set; }
        public int? RateCount { get; set; }
        public string BiographyKey { get; set; }
        public string ShortBiographyKey { get; set; }
        public string ProfilePhotoPath { get; set; }
        public string WallpaperPath { get; set; }

        public string ProfessionNameKey { get; set; }
        public string ProfessionDescriptionKey { get; set; }
        public DateTime? StartProfessionCareer { get; set; }
        public ProfessionDegree ProfessionDegree { get; set; }

        public string CompanyNameKey { get; set; }
        public string JobDescriptionKey { get; set; }

        public List<GetTeacherSocialMediaDto> TeacherSocialMedias { get; set; }
        public List<GetTeacherCourseDto> TeacherCourses { get; set; }
    }
}
