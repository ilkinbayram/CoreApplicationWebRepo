using System.Collections.Generic;

namespace Core.Entities.Dtos.User
{
    public class FilterCelebritiesFeatureDto
    {
        public long Id { get; set; }
        public string FeatureName { get; set; }
        public List<FilterCelebritiesFeatureValueDto> FeatureValues { get; set; }
    }
}
