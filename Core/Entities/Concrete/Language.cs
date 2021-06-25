using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Language : IEntity
    {
        public long Id { get; set; }
        public string LanguageName { get; set; }
        public bool IsActive { get; set; }

        public virtual IEnumerable<UserLanguage> FameousPersonLanguages { get; set; }
        public virtual IEnumerable<CategoryLanguage> CategoryLanguages { get; set; }
        public virtual IEnumerable<MessageLanguage> MessageLanguages { get; set; }
        public virtual IEnumerable<HomeMetaTagLanguage> HomeMetaTagLanguages { get; set; }
        public virtual IEnumerable<SectionLanguage> SectionLanguages { get; set; }
        public virtual IEnumerable<FeatureValueLanguage> FeatureValueLanguages { get; set; }
        public virtual IEnumerable<FeatureLanguage> FeatureLanguages { get; set; }


    }
}
