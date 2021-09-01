using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.Category
{
    /// <summary>
    /// Kateqoriya əlavə et modeli
    /// </summary>
    public class CreateCategoryDto
    {
        /// <summary>
        /// Üst kateqoriya İd-si
        /// </summary>
        public Nullable<int> ParentCategoryId { get; set; }
        public bool ShowInHomePage { get; set; }
        /// <summary>
        /// Kateqoriya dilə görə əlavə et model listi
        /// </summary>
        public string Banner { get; set; }
        public List<CreateCategoryLangDto> CategoryLanguages { get; set; }
        /// <summary>
        /// Kateqoriyanin field listi
        /// </summary>
        public List<CreateCategoryFeatureDto> CategoryFeatures { get; set; }

    }
}
