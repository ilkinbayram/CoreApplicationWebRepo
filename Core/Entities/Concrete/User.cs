using System;
using System.Collections.Generic;

using Core.Entities.Abstract;
using Core.Entities.Concrete.Base;
using Core.Resources.Enums;



namespace Core.Entities.Concrete
{
    public class User : BaseEntity, IEntity, IUserBaseEntity
    {
        public User()
        {
            ModelType = ProjectModelType.User;
        }

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
        public AccountType AccountType { get; set; }
        public string SecurityToken { get; set; }

        public virtual List<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual List<UserSocialMedia> UserSocialMedias { get; set; }
        //public virtual List<Blog> Blogs { get; set; }
    }
}
