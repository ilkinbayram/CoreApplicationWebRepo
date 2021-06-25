using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual IEnumerable<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
