using System;

using Core.Entities.Concrete.Base;
using Core.Resources.Enums;


namespace Core.Entities.Concrete
{
    public class Profession : BaseEntity, IEntity
    {
        public Profession()
        {
            ModelType = ProjectModelType.Profession;
        }

        public string NameKey { get; set; }
        public string SubnameKey { get; set; }
        public string DescriptionKey { get; set; }
        public DateTime StartProfession { get; set; }
        public ProfessionDegree ProfessionDegree { get; set; }
        
        public virtual Teacher Teacher { get; set; }
    }
}
