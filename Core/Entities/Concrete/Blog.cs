using Core.Entities.Concrete.Base;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Blog : BaseEntity, IEntity
    {
        public string UniqueToken { get; set; }
        public string CaptionSource { get; set; }
        public string OwnerProfessionKey { get; set; }
        public string TitleKey { get; set; }
        public string SubtitleKey { get; set; }
        public string ContentHtmlRawKey { get; set; }
        public string OverviewHtmlRawKey { get; set; }
        public PostScreenType ScreenType { get; set; }

        public virtual BlogCategory BlogCategory { get; set; }
        public virtual List<TagBlog> TagBlogs { get; set; }
        public virtual User User { get; set; }
    }
}
