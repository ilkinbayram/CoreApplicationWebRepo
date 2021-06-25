using System;
using System.Collections.Generic;

namespace Core.Entities.Dtos.Category
{
    public class CategoryEditDto
    {
        public long Id { get; set; }
        public Nullable<int> ParentCategoryId { get; set; }
        public bool ShowInHomePage { get; set; }
        public string Banner { get; set; }
        public IEnumerable<EditCategoryLangDto> CategoryLanguages { get; set; }
        public IEnumerable<EditCategoryFeatureDto> CategoryFeatures { get; set; }
    }
}

