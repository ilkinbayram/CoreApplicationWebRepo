using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.User
{
    public class GetByIdUserFeatureValue
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public long CategoryFeatureId { get; set; }
        public long FeatureValueId { get; set; }
    }
}
