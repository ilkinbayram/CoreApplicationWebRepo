using Core.Entities.Dtos.Base;
using Core.Resources.Enums;



namespace Core.Entities.Dtos.ProfessionCourseCategory
{
    public class CreateManagementProfessionCourseCategoryDto : BaseDto
    {
        public CreateManagementProfessionCourseCategoryDto()
        {
            ModelType = ProjectModelType.ProfessionCourseCategory;
        }
    }
}
