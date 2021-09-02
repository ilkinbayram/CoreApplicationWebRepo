using Core.Entities.Abstract;
using Core.Entities.Dtos.BlogCategory;
using Core.Entities.Dtos.TagBlog;
using Core.Entities.Dtos.User;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;

namespace Core.Entities.Dtos.Blog
{
    public class GetBlogDto : IBaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public string UniqueToken { get; set; }
        public string CaptionSource { get; set; }
        public string OwnerProfessionKey { get; set; }
        public string TitleKey { get; set; }
        public string SubtitleKey { get; set; }
        public string PreviewDescriptionKey { get; set; }
        public string ContentHtmlRawKey { get; set; }
        public string OverviewHtmlRawKey { get; set; }
        public PostScreenType ScreenType { get; set; }

        public long UserId { get; set; }

        public GetBlogCategoryDto BlogCategory { get; set; }
        public List<GetTagBlogDto> TagBlogs { get; set; }
        public GetUserDto User { get; set; }
    }
}
