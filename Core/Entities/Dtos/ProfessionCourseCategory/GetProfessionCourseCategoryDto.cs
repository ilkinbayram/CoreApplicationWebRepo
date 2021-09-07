using System.Collections.Generic;
using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Course;
using Core.Resources.Enums;


namespace Core.Entities.Dtos.ProfessionCourseCategory
{
    public class GetProfessionCourseCategoryDto : BaseDto
    {
        public GetProfessionCourseCategoryDto()
        {
            ModelType = ProjectModelType.ProfessionCourseCategory;
        }

        public string NameKey { get; set; }
        public string IconSource { get; set; }
        public string DescriptionKey { get; set; }

        public long? ParentCategoryId { get; set; }

        public HashSet<GetProfessionCourseCategoryDto> Children { get; set; } //ozunden ozune relation ucun ve childlari
        public GetProfessionCourseCategoryDto ParentCategory { get; set; }
        public List<GetCourseDto> Courses { get; set; }
    }
}
