using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.Home
{
    public class CreateHomeMetaTagGalleryDto
    {
        public string Url { get; set; }
        public long Order { get; set; }
        public string Alt { get; set; }
        public bool IsActive { get; set; }
        public long HomeMetaTagId { get; set; }
    }
}
