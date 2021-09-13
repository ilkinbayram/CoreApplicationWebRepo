namespace Core.Entities.Dtos.User
{
    public class CelebrityProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BelongingCategoryName { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public string ProfilePhotoId { get; set; }
        public string ProfilePhoto { get; set; }
        public string WallpaperId { get; set; }
        public string Wallpaper { get; set; }
    }
}
