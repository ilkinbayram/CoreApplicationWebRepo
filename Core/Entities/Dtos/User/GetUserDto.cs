using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Blog;
using Core.Entities.Dtos.UserSocialMedia;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;


namespace Core.Entities.Dtos.User
{
    public class GetUserDto : BaseDto
    {
        public GetUserDto()
        {
            ModelType = ProjectModelType.User;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProfilePhotoPath { get; set; }
        public string WallpaperPath { get; set; }
        public string PhoneNumberPrefix { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public string BiographyKey { get; set; }
        public AccountType AccountType { get; set; }
        public string SecurityToken { get; set; }
        public virtual List<GetUserSocialMediaDto> UserSocialMedias { get; set; }
        public virtual List<GetBlogDto> Blogs { get; set; }

    }
}
