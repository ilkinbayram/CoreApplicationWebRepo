using System.Collections.Generic;
using Core.Entities.Concrete.Base;

namespace Core.Entities.Concrete
{
    public class Category:BaseEntity,IEntity
    {
        public long? ParentCategoryId { get; set; }
        public bool  ShowInHomePage { get; set; }
        public string  Banner { get; set; }
        public virtual HashSet<Category> Children { get; set; } //ozunden ozune relation ucun ve childlari
        public virtual Category ParentCategory { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<CategoryFeature> CategoryFeatures { get; set; }
        public virtual IEnumerable<CategoryLanguage> CategoryLanguages { get; set; }

    }
}
