namespace Core.Entities.Dtos.User
{
    public class UpdateUserLanguageDto
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public long LanguageId { get; set; }
        public string Slug { get; set; }
    }
}
