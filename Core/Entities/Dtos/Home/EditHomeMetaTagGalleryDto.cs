using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.Home
{
    public class EditHomeMetaTagGalleryDto
    {
        public long? Id { get; set; }
        public string Url { get; set; }
        public long Order { get; set; }
        public string Alt { get; set; }
        public bool IsActive { get; set; }
        public long? HomeMetaTagId { get; set; }
    }
}
