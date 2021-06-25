namespace Core.Entities.Concrete
{
    public class UserOperationClaim:IEntity
    {
        public long Id { get; set; }
        public bool IsActive { get; set; }
        public long UserId { get; set; }
        public long OperationClaimId { get; set; }
        public virtual User User { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }
    }
}
