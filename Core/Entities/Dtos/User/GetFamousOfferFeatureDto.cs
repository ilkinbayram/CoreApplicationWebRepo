using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.User
{
    public class GetFamousOfferFeatureDto
    {
        public string FeatureName { get; set; }
        public List<GetFamousOfferFeatureValueDto> FeatureValues { get; set; }
    }
}
