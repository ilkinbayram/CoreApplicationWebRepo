using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.Category
{
    public class CategoryLangClientDto
    {
        /// <summary>
        /// İd-si
        /// </summary>
        public long Id { get; set; }
        public long CategoryId { get; set; }
        /// <summary>
        /// Dilin İd-si
        /// </summary>
        public int LanguageId { get; set; }
        /// <summary>
        /// Kateqoriyanın adı
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Kateqoriya haqqında
        /// </summary>
        public string Description { get; set; }
        public string Slug { get; set; }
        public bool  IsRoot { get; set; }
        public string Banner { get; set; }
    }
}
