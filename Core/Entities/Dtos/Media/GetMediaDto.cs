using Core.Entities.Abstract;
using Core.Entities.Dtos.SharingTypeMedia;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;

namespace Core.Entities.Dtos.Media
{
    public class GetMediaDto : IBaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public string Source { get; set; }
        public string AltrKey { get; set; }
        public string UniqueParentToken { get; set; }
        public MediaType MediaType { get; set; }

        public List<GetSharingTypeMediaDto> SharingTypeMedias { get; set; }
    }
}
