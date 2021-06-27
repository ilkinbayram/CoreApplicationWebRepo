using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Language : IEntity
    {
        public long Id { get; set; }
        public string NameKey { get; set; }
        public bool IsActive { get; set; }
    }
}
