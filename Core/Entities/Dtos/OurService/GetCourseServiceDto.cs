using Core.Entities.Dtos.Base;

namespace Core.Entities.Dtos.OurService
{
    public class GetCourseServiceDto : BaseDto
    {
        public string TitleKey { get; set; }
        public string DescriptionKey { get; set; }
        public string UniqueToken { get; set; }
        public string IconSource { get; set; }
    }
}
