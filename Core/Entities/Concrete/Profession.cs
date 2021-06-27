using Core.Entities.Concrete.Base;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Profession : BaseEntity, IEntity
    {
        public string NameKey { get; set; }
        public string SubnameKey { get; set; }
        public string ProfDescKey { get; set; }
        public DateTime StartProfession { get; set; }
        public ProfessionDegree ProfessionDegree { get; set; }
        public string CurrentCompanyKey { get; set; }
        public string CurrentPositionAtCompanyKey { get; set; }

        public virtual HashSet<Profession> SubProfession { get; set; }
        public virtual Profession ParentProfession { get; set; }
        public virtual List<TeacherInfo> TeacherInfos { get; set; }
    }
}
