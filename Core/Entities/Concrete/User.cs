using System;
using System.Collections.Generic;
using Core.Entities.Concrete.Base;
using Core.Resources.Enums;

namespace Core.Entities.Concrete
{
    public class User : BaseEntity, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProfilePhotoPath { get; set; }
        public string WallpaperPath { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string PhoneNumberPrefix { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public decimal? Rate { get; set; }
        public int? RateCount { get; set; }
        public string BiographyKey { get; set; }
        public AccountType AccountType { get; set; }
        public string SecurityToken { get; set; }

        public virtual List<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual TeacherInfo TeacherInfo { get; set; }
        public virtual List<UserSocialMedia> UserSocialMedias { get; set; }
        public virtual List<Post> Posts { get; set; }
        public virtual List<UserCourse> UserCourses { get; set; }
    }
}
