using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

using Core.Entities.Dtos.Base;
using Core.Resources.Enums;
using Core.Utilities.UsableModel;

namespace Core.Entities.Dtos.BlogCategory
{
    public class CreateBlogCategoryManagementDto : BaseDto
    {
        public CreateBlogCategoryManagementDto()
        {
            ResponseMessages = new List<AlertResult>();
            ModelType = ProjectModelType.BlogCategory;
        }

        public string NameKey { get; set; }
        public string NameTranslateENG { get; set; }
        public string NameTranslateAZE { get; set; }
        public string NameTranslateTUR { get; set; }
        public string NameTranslateRUS { get; set; }
        public string DescKey { get; set; }
        public string DescTranslateAZE { get; set; }
        public string DescTranslateRUS { get; set; }
        public string DescTranslateTUR { get; set; }
        public string DescTranslateENG { get; set; }
        public IFormFile IconFile { get; set; }
        public string IconSource { get; set; }
        public long? ParentCategoryId { get; set; }
        public List<SelectListItem> ParentBlogCategories { get; set; }

        public HashSet<CreateBlogCategoryManagementDto> Children { get; set; } //ozunden ozune relation ucun ve childlari
        public CreateBlogCategoryManagementDto ParentCategory { get; set; }

        public List<AlertResult> ResponseMessages { get; set; }
    }
}
