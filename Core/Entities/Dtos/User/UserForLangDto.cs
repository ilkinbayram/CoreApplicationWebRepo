using Core.Entities.Dtos.User;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.User
{
    public class UserForLangDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProfilePhotoPath { get; set; }
        public string ProfilePhotoPathCloudinaryUrl { get; set; }

        public string WallpaperPath { get; set; }
        public string WallpaperPathCloudinaryUrl { get; set; }

        public string PhoneNumberPrefix { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public AccountType AccountType { get; set; }
        public string Biography { get; set; }
        public decimal? UnitPrice { get; set; }
        public string PreviewMoviePath { get; set; }
        public string PreviewMoviePathCloudinaryUrl { get; set; }



        public long? CategoryId { get; set; }
        public bool ShowInHomePage { get; set; }

        public virtual List<GetByIdUserFeatureValue> UserFeatureValues { get; set; }
    }
}
