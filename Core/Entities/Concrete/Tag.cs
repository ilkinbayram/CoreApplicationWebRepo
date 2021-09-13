using System.Collections.Generic;

using Core.Entities.Concrete.Base;
using Core.Resources.Enums;





namespace Core.Entities.Concrete
{
    public class Tag : BaseEntity, IEntity
    {
        public Tag()
        {
            ModelType = ProjectModelType.Tag;
        }

        public string Name { get; set; }
        public TagTypeEnum TagType { get; set; }


        public virtual List<TagBlog> TagBlogs { get; set; }
    }
}
