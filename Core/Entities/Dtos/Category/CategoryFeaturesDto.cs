using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.Category
{
    public class CategoryFeatureListDto
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public long FeatureId { get; set; }
    }
}
