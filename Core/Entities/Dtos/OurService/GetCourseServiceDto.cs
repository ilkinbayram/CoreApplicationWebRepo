using Core.Entities.Dtos.Base;
using Core.Resources.Enums;



namespace Core.Entities.Dtos.OurService
{
    public class GetCourseServiceDto : BaseDto
    {
        public GetCourseServiceDto()
        {
            ModelType = ProjectModelType.CourseService;
        }
        public string TitleKey { get; set; }
        public string DescriptionKey { get; set; }
        public string UniqueToken { get; set; }
        public string IconSource { get; set; }
    }
}
