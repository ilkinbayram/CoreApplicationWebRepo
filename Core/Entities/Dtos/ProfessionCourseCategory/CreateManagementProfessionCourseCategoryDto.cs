using Core.Entities.Dtos.Base;
using Core.Resources.Enums;
using Core.Utilities.UsableModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Core.Entities.Dtos.ProfessionCourseCategory
{
    public class CreateManagementProfessionCourseCategoryDto : BaseDto
    {
        public CreateManagementProfessionCourseCategoryDto()
        {
            ResponseMessages = new List<AlertResult>();
            ModelType = ProjectModelType.ProfessionCourseCategory;
        }

        public string NameKey { get; set; }
        public string NameTranslateENG { get; set; }
        public string NameTranslateAZE { get; set; }
        public string NameTranslateTUR { get; set; }
        public string NameTranslateRUS { get; set; }
        public string IconSource { get; set; }
        public IFormFile IconFile { get; set; }
        public string DescriptionKey { get; set; }
        public string DescriptionTranslateAZE { get; set; }
        public string DescriptionTranslateRUS { get; set; }
        public string DescriptionTranslateTUR { get; set; }
        public string DescriptionTranslateENG { get; set; }

        public long? ParentCategoryId { get; set; }

        public List<SelectListItem> ParentProfessionCourseCategories { get; set; }

        public HashSet<CreateManagementProfessionCourseCategoryDto> Children { get; set; } //ozunden ozune relation ucun ve childlari
        public CreateManagementProfessionCourseCategoryDto ParentCategory { get; set; }

        public List<AlertResult> ResponseMessages { get; set; }
    }
}
