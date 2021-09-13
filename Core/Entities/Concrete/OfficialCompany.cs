using System.Collections.Generic;

using Core.Entities.Concrete.Base;
using Core.Resources.Enums;



namespace Core.Entities.Concrete
{
    public class OfficialCompany : BaseEntity, IEntity
    {
        public OfficialCompany()
        {
            ModelType = ProjectModelType.OfficialCompany;
        }

        public string WebUrl { get; set; }
        public string CaptionImageSource { get; set; }
        public string Location { get; set; }
        public string NameKey { get; set; }
        public string DescriptionKey { get; set; }

        public virtual List<TeacherOfficialCompany> TeacherOfficialCompanies { get; set; }
    }
}
