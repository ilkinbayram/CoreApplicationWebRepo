using Core.Entities.Concrete.Base;
using Core.Resources.Enums;




namespace Core.Entities.Concrete
{
    public class CourseService : BaseEntity, IEntity
    {
        public CourseService()
        {
            ModelType = ProjectModelType.CourseService;
        }

        public string TitleKey { get; set; }
        public string DescriptionKey { get; set; }
        public string UniqueToken { get; set; }
        public string IconSource { get; set; }
        public string IconHtml { get; set; }
    }
}
