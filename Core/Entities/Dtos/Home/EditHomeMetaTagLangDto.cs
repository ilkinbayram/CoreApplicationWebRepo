using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.Home
{
    public class EditHomeMetaTagLangDto
    {
        public long? Id { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Keywords { get; set; }
        public string Tag { get; set; }
        public string SearchKeyword { get; set; }
        public bool IsActive { get; set; }
        public long? HomeMetaTagId { get; set; }
        public long? LanguageId { get; set; }
    }
}
