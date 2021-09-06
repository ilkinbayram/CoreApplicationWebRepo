using Core.Entities.Abstract;
using Core.Entities.Dtos.SharingTypeMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.SharingType
{
    public class GetSharingTypeDto : BaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public string NameKey { get; set; }

        public List<GetSharingTypeMediaDto> SharingTypeMedias { get; set; }
    }
}
