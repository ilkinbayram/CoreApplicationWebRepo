using Core.Entities.Abstract;
using Core.Entities.Dtos.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.ProfessionCourseCategory
{
    public class GetProfessionCourseCategoryDto : BaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public string NameKey { get; set; }
        public string IconSource { get; set; }
        public string DescriptionKey { get; set; }

        public long? ParentCategoryId { get; set; }

        public HashSet<GetProfessionCourseCategoryDto> Children { get; set; } //ozunden ozune relation ucun ve childlari
        public GetProfessionCourseCategoryDto ParentCategory { get; set; }
        public List<GetCourseDto> Courses { get; set; }
    }
}
