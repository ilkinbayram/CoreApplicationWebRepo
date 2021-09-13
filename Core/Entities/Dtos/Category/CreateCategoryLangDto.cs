namespace Core.Entities.Dtos.Category
{
    /// <summary>
    /// Kateqoriya əlavə et dilə görə
    /// </summary>
    public class CreateCategoryLangDto
    {
        /// <summary>
        /// Dil İd-si
        /// </summary>
        public int? LanguageId { get; set; }
        /// <summary>
        /// Kateqoriya adı
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Kateqoriya haqqında
        /// </summary>
        public string Description { get; set; }
        public string Slug { get; set; }
    }
}
