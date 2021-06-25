namespace Core.Entities.Concrete
{
    public class UserLanguage : IEntity
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public long LanguageId { get; set; }
        public long UserId { get; set; }
        public string Slug { get; set; }
        public virtual Language Language { get; set; }
        public virtual User User { get; set; }

    }
}
