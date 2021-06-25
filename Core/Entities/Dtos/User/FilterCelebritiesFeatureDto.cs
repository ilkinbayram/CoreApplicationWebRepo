using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.User
{
    public class FilterCelebritiesFeatureDto
    {
        public long Id { get; set; }
        public string FeatureName { get; set; }
        public List<FilterCelebritiesFeatureValueDto> FeatureValues { get; set; }
    }
}
