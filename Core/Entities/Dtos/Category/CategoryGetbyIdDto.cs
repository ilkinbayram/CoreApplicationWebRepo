using System;
using System.Collections.Generic;

namespace Core.Entities.Dtos.Category
{
    public class CategoryGetbyIdDto
    {
        public long Id { get; set; }
        /// <summary>
        /// Üst kateqoriya İd-si
        /// </summary>
        public Nullable<int> ParentCategoryId { get; set; }
        /// <summary>
        /// Esas sehifede gosterilsinmi ?
        /// </summary>
        public bool ShowInHomePage { get; set; }
        public string Banner { get; set; }
        public string BannerCloudinaryUrl { get; set; }

        /// <summary>
        /// Kateqoriyanın dil model listi
        /// </summary>
        public IEnumerable<CategoryLangDto> CategoryLanguages { get; set; }
        /// <summary>
        /// Xüsusiyyətlərin model listi
        /// </summary>
        public IEnumerable<CategoryFeatureDto> CategoryFeatures { get; set; }
    }
}
