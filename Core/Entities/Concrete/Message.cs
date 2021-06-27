using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Message : IEntity
    {
        public long Id { get; set; }
        public long MessageCode { get; set; }
        public bool IsActive { get; set; }
    }
}
