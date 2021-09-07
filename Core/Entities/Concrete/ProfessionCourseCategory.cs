using System.Collections.Generic;
using Core.Entities.Concrete.Base;
using Core.Resources.Enums;

namespace Core.Entities.Concrete
{
    public class ProfessionCourseCategory : BaseEntity, IEntity
    {
        public ProfessionCourseCategory()
        {
            ModelType = ProjectModelType.ProfessionCourseCategory;
        }

        public string NameKey { get; set; }
        public string IconSource { get; set; }
        public string DescriptionKey { get; set; }

        public long? ParentCategoryId { get; set; }

        public virtual HashSet<ProfessionCourseCategory> Children { get; set; } //ozunden ozune relation ucun ve childlari
        public virtual ProfessionCourseCategory ParentCategory { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}
