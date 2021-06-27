using Core.Entities.Abstract;
using System;

namespace Core.Entities.Concrete.Base
{
    public class BaseEntity : IBaseEntity
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public string Modified_by { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Modified_at { get; set; }
        public bool IsActive { get; set; }
    }
}
