using Core.Entities.Concrete.Base;
using Core.Resources.Enums;

namespace Core.Entities.Concrete
{
    public class TagBlog : BaseEntity, IEntity
    {
        public TagBlog()
        {
            ModelType = ProjectModelType.TagBlog;
        }

        public long TagId { get; set; }
        public long BlogId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Blog Blog { get; set; }

    }
}
