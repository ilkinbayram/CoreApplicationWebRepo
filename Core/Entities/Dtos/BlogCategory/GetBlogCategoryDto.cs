using System.Collections.Generic;

using Core.Entities.Dtos.Base;
using Core.Resources.Enums;



namespace Core.Entities.Dtos.BlogCategory
{
    public class GetBlogCategoryDto : BaseDto
    {
        public GetBlogCategoryDto()
        {
            ModelType = ProjectModelType.BlogCategory;
        }
        public string NameKey { get; set; }
        public string DescKey { get; set; }
        public string IconSource { get; set; }
        public long? ParentCategoryId { get; set; }

        public HashSet<GetBlogCategoryDto> Children { get; set; } //ozunden ozune relation ucun ve childlari
        public GetBlogCategoryDto ParentCategory { get; set; }
    }
}
