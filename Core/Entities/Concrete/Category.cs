using System.Collections.Generic;
using Core.Entities.Concrete.Base;
using Core.Resources.Enums;

namespace Core.Entities.Concrete
{
    public class Category:BaseEntity,IEntity
    {
        public string NameKey { get; set; }
        public string DescKey { get; set; }
        public long? ParentCategoryId { get; set; }
        public bool ShowInHomePage { get; set; }
        public DirectCategoryType CategoryType { get; set; }
        public string IconSource { get; set; }
        // public string Banner { get; set; }

        public virtual HashSet<Category> Children { get; set; } //ozunden ozune relation ucun ve childlari
        public virtual Category ParentCategory { get; set; }
        public virtual List<User> Users { get; set; }

    }
}
