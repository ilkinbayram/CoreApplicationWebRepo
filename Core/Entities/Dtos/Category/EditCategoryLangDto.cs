namespace Core.Entities.Dtos.Category
{
    public class EditCategoryLangDto
    {
        public long? Id { get; set; }
        public int? LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
    }
}
