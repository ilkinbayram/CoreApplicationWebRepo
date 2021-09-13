namespace Core.Entities.Dtos.Category
{
    public class CategoryGetLangDto
    {
        /// <summary>
        /// İd-si
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Dilin İd-si
        /// </summary>
        public int LanguageId { get; set; }
        /// <summary>
        /// Kateqoriyanın adı
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Kateqoriya haqqında
        /// </summary>
        public string Description { get; set; }
        public string Slug { get; set; }
        public CategoryClientDto Category { get; set; }
    }
}
