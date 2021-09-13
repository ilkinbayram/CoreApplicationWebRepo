using Core.Entities.Concrete.Base;
using Core.Resources.Enums;





namespace Core.Entities.Concrete
{
    public class Language : BaseEntity, IEntity
    {
        public Language()
        {
            ModelType = ProjectModelType.Language;
        }

        public string NameKey { get; set; }
        public string FlagIconSource { get; set; }
        public string NameAbr { get; set; }
        public string FullName { get; set; }
        public string CourseLanguageKey { get; set; }
    }
}
