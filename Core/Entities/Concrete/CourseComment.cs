using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class CourseComment : BaseEntity, IEntity
    {
        public string OwnerEmail { get; set; }

        public virtual Course Course { get; set; }
    }
}
