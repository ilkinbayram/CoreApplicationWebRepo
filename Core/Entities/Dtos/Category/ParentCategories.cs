using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.Category
{
    public class ParentCategories
    {
        /// İd-si
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Alt kateqoriyası varmı
        /// </summary>
        public bool HasChildren { get; set; }
       /// <summary>
        /// Kateqoriyanın dil model listi
        /// </summary>
        public List<CategoryLangDto> CategoryLanguages { get; set; }
        public List<CategoryFeatureListDto> CategoryFeatures { get; set; }

    }
}
