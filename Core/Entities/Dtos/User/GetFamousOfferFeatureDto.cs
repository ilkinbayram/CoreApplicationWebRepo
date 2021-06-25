using Core.Entities.Dtos.Feature;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.User
{
    public class GetFamousOfferFeatureDto
    {
        public string FeatureName { get; set; }
        public IEnumerable<GetFamousOfferFeatureValueDto> FeatureValues { get; set; }
    }
}
