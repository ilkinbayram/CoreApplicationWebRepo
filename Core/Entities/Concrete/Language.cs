using Core.Entities.Concrete.Base;
using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Language : BaseEntity, IEntity
    {
        public Language()
        {
            ModelType = ProjectModelType.Language;
        }

        public short Language_oid { get; set; }
        public string NameKey { get; set; }
        public string FlagIconSource { get; set; }
        public string NameAbr { get; set; }


        public virtual List<Course> Courses { get; set; }
    }
}
