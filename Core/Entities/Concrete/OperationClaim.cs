using System.Collections.Generic;

using Core.Entities.Concrete.Base;
using Core.Resources.Enums;




namespace Core.Entities.Concrete
{
    public class OperationClaim : BaseEntity, IEntity
    {
        public OperationClaim()
        {
            ModelType = ProjectModelType.OperationClaim;
        }

        public string Name { get; set; }

        public virtual List<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual List<TeacherOperationClaim> TeacherOperationClaims { get; set; }
        public virtual List<StudentOperationClaim> StudentOperationClaims { get; set; }
    }
}
