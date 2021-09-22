using Core.Entities.Concrete.Base;
using Core.Resources.Enums;




namespace Core.Entities.Concrete
{
    public class TeacherOperationClaim : BaseEntity, IEntity
    {
        public TeacherOperationClaim()
        {
            ModelType = ProjectModelType.TeacherOperationClaim;
        }

        public long TeacherId { get; set; }
        public long OperationClaimId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }
    }
}
