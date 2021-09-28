using Core.Entities.Abstract;
using Core.Entities.Concrete.Base;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;




namespace Core.Entities.Concrete
{
    public class Teacher : BaseEntity, IEntity, IUserBaseEntity
    {
        public Teacher()
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
        public string BiographyKey { get; set; }
        public string ShortBiographyKey { get; set; }
        public string ProfilePhotoPath { get; set; }
        public string WallpaperPath { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public string ProfessionNameKey { get; set; }
        public string ProfessionDescriptionKey { get; set; }
        public DateTime? StartProfessionCareer { get; set; }
        public ProfessionDegree ProfessionDegree { get; set; }

        public string CompanyNameKey { get; set; }
        public string JobDescriptionKey { get; set; }

        public virtual List<TeacherOperationClaim> TeacherOperationClaims { get; set; }
        public virtual List<TeacherCourse> TeacherCourses { get; set; }
        public virtual List<TeacherSocialMedia> TeacherSocialMedias { get; set; }
    }
}
