using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Language : IEntity
    {
        public long Id { get; set; }
        public string NameKey { get; set; }
        public string FlagIconSource { get; set; }
        public string NameAbr { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public string CourseLanguageKey { get; set; }
    }
}
