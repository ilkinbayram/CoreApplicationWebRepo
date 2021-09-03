using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.BlogCategory
{
    public class CreateBlogCategoryManagementDto : IBaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public string NameKey { get; set; }
        public string NameTranslateENG { get; set; }
        public string NameTranslateAZE { get; set; }
        public string NameTranslateTUR { get; set; }
        public string NameTranslateRUS { get; set; }
        public string DescKey { get; set; }
        public string DescTranslateAZE { get; set; }
        public string DescTranslateRUS { get; set; }
        public string DescTranslateTUR { get; set; }
        public string DescTranslateENG { get; set; }
        public string IconSource { get; set; }
        public long? ParentCategoryId { get; set; }

        public HashSet<CreateBlogCategoryManagementDto> Children { get; set; } //ozunden ozune relation ucun ve childlari
        public CreateBlogCategoryManagementDto ParentCategory { get; set; }
    }
}
