using Core.Entities.Concrete.Base;
using Core.Resources.Enums;




namespace Core.Entities.Concrete
{
    public class StudentOperationClaim : BaseEntity, IEntity
    {
        public StudentOperationClaim()
        {
            ModelType = ProjectModelType.StudentOperationClaim;
        }

        public long StudentId { get; set; }
        public long OperationClaimId { get; set; }
        public virtual Student Student { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }
    }
}
