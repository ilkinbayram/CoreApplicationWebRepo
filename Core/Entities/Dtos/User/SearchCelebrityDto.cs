namespace Core.Entities.Dtos.User
{
    public class SearchCelebrityDto : IDto
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

        public string Language { get; set; }
        public string Category { get; set; }
    }
}
