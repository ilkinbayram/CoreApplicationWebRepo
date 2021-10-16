using System.Collections.Generic;

using Core.Entities.Concrete.Base;
using Core.Resources.Enums;
using Microsoft.AspNetCore.Http;

namespace Core.Entities.Concrete
{
    public class Blog : BaseEntity, IEntity
    {
        public Blog()
        {
            ModelType = ProjectModelType.Blog;
        }

        public string UniqueToken { get; set; }
        public string CaptionSource { get; set; }
        //public string OwnerProfessionKey { get; set; }
        public string TitleKey { get; set; }
        public string SubtitleKey { get; set; }
        public string PreviewDescriptionKey { get; set; }
        public string ContentHtmlRawKey { get; set; }
        //public string OverviewHtmlRawKey { get; set; }
        public PostScreenType ScreenType { get; set; }

        public long BlogCategoryId { get; set; }
        //public long UserId { get; set; }

        public virtual BlogCategory BlogCategory { get; set; }
        public virtual List<TagBlog> TagBlogs { get; set; }
        //public virtual User User { get; set; }
    }
}
