using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.User
{
    public class GetCelebrityDtoForOrder
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal? UnitPrice { get; set; }
        public string ProfilePhotoId { get; set; }
        public string ProfilePhoto { get; set; }
        public string WallpaperId { get; set; }
        public string Wallpaper { get; set; }
        public string PreviewMovieId { get; set; }
        public string PreviewMovie { get; set; }
        public string Slug { get; set; }
        public int? RateCount { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? Created_at { get; set; }
    }
}
