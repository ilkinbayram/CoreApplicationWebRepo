using Core.Entities.Concrete.Base;
using Core.Resources.Enums;




namespace Core.Entities.Concrete
{
    public class UserOperationClaim: BaseEntity, IEntity
    {
        public UserOperationClaim()
        {
            ModelType = ProjectModelType.UserOperationClaim;
        }

        public long UserId { get; set; }
        public long OperationClaimId { get; set; }
        public virtual User User { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }
    }
}
