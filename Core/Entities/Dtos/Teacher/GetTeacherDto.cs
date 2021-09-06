using Core.Entities.Abstract;
using Core.Entities.Dtos.Profession;
using Core.Entities.Dtos.TeacherCourse;
using Core.Entities.Dtos.TeacherSocialMedia;
using Core.Entities.Dtos.UserCourse;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;

namespace Core.Entities.Dtos.Teacher
{
    public class GetTeacherDto : BaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumberPrefix { get; set; }
        public string PhoneNumber { get; set; }
        public string PreviewMoviePath { get; set; }
        public string IconSource { get; set; }
        public string SecurityToken { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public decimal? Rate { get; set; }
        public int? RateCount { get; set; }
        public string BiographyKey { get; set; }
        public string ProfilePhotoPath { get; set; }
        public string WallpaperPath { get; set; }

        public long ProfessionId { get; set; }

        public GetProfessionDto Profession { get; set; }
        public List<GetTeacherSocialMediaDto> TeacherSocialMedias { get; set; }
        public List<GetTeacherCourseDto> TeacherCourses { get; set; }
        public List<GetUserCourseDto> UserCourses { get; set; }
    }
}
