using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.Home
{
    public class GetHomeMetaTagDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<GetHomeMetaTagGalleryDto> HomeMetaTagGalleries { get; set; }
        public IEnumerable<GetHomeMetaTagLangDto> HomeMetaTagLanguages { get; set; }
    }
}
