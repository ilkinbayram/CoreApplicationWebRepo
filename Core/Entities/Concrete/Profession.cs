using System;
using System.Collections.Generic;
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
        public string ProfDescKey { get; set; }
        public DateTime StartProfession { get; set; }
        public ProfessionDegree ProfessionDegree { get; set; }
        public string CurrentCompanyKey { get; set; }
        public string CurrentPositionAtCompanyKey { get; set; }
        public long? ParentProfessionId { get; set; } 


        public virtual HashSet<Profession> SubProfession { get; set; }
        public virtual Profession ParentProfession { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
    }
}
