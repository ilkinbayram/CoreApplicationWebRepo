using System.Collections.Generic;

namespace Core.Entities.Dtos.Category
{
    public class CategoryListDto
    {
        /// <summary>
        /// İd-si
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Ana səhifədə göstərilməsi
        /// </summary>
        public bool ShowInHomePage { get; set; }
        /// <summary>
        /// Alt kateqoriyası varmı
        /// </summary>
        public bool HasChildren { get; set; }
        /// <summary>
        /// Məhsul sayı
        /// </summary>
        public int UserCount { get; set; }
        public long? ParentCategoryId { get; set; }
        public string Banner { get; set; }

        /// <summary>
        /// Kateqoriyanın dil model listi
        /// </summary>
        public List<CategoryLangDto> CategoryLanguages { get; set; }
        public List<CategoryFeatureListDto> CategoryFeatures { get; set; }

        /// <summary>
        /// Alt kateqoriyaların model listi
        /// </summary>
        public List<CategoryListDto> Children { get; set; } = new List<CategoryListDto>();
    }
}
