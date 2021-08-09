using System.Collections.Generic;
using Core.Entities.Concrete.Base;
using Core.Resources.Enums;

namespace Core.Entities.Concrete
{
    public class BlogCategory : BaseEntity, IEntity
    {
        public string NameKey { get; set; }
        public string DescKey { get; set; }
        public long? ParentCategoryId { get; set; }
        public bool ShowInHomePage { get; set; }
        public string IconSource { get; set; }
        // public string Banner { get; set; }

        public virtual HashSet<BlogCategory> Children { get; set; } //ozunden ozune relation ucun ve childlari
        public virtual BlogCategory ParentCategory { get; set; }
        public virtual List<Blog> Blogs { get; set; }
    }
}
