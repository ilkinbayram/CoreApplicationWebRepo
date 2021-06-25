using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.Home
{
    public class CreateHomeMetaTagDto
    {
        public IEnumerable<CreateHomeMetaTagLangDto> HomeMetaTagLanguages { get; set; }
        public IEnumerable<CreateHomeMetaTagGalleryDto> HomeMetaTagGalleries { get; set; }
    }
}
