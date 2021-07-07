using Core.Entities.Concrete.Base;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Post : BaseEntity, IEntity
    {
        public string PostOwner { get; set; }
        public string CaptionSource { get; set; }
        public string OwnerProfessionKey { get; set; }
        public string TitleKey { get; set; }
        public string SubtitleKey { get; set; }
        public string ContentKey { get; set; }
        public bool IsHtmlContent { get; set; }
        public PostScreenType ScreenType { get; set; }

        public virtual List<Media> Medias { get; set; }
        public virtual Section Section { get; set; }
        public virtual List<SharingTypePost> SharingTypePosts { get; set; }
        public virtual List<TagPosts> TagPosts { get; set; }

        public virtual User User { get; set; }
    }
}
