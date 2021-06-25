using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.User
{
    public class GetByIdUserLanguage
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public long LanguageId { get; set; }
        public long UserId { get; set; }
        public string Slug { get; set; }
    }
}
