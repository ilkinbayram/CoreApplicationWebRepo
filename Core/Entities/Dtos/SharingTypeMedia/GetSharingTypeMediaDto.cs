using Core.Entities.Abstract;
using Core.Entities.Dtos.Media;
using Core.Entities.Dtos.SharingType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.SharingTypeMedia
{
    public class GetSharingTypeMediaDto : IBaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public long MediaId { get; set; }
        public long SharingTypeId { get; set; }

        public GetMediaDto Media { get; set; }
        public GetSharingTypeDto SharingType { get; set; }
    }
}
