using Core.Entities.Abstract;
using Core.Entities.Concrete.Base;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Teacher : BaseEntity, IEntity, IUserBaseEntity
    {
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
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public long ProfessionId { get; set; }
        
        public virtual Profession Profession { get; set; }
        public virtual List<TeacherCourse> TeacherCourses { get; set; }
        public virtual List<TeacherSocialMedia> TeacherSocialMedias { get; set; }
        public virtual List<UserCourse> UserCourses { get; set; }
    }
}
