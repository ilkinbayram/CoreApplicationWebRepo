using System.Collections.Generic;
using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.BlogCategory;
using Core.Entities.Dtos.TagBlog;
using Core.Entities.Dtos.User;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.Blog
{
    public class GetBlogForManagementDto : BaseDto
    {
        public GetBlogForManagementDto()
        {
            ModelType = ProjectModelType.Blog;
        }

        public string UniqueToken { get; set; }
        public string CaptionSource { get; set; }
        public string OwnerProfessionKey { get; set; }
        public string OwnerProfessionTranslateAZE { get; set; }
        public string OwnerProfessionTranslateRUS { get; set; }
        public string OwnerProfessionTranslateENG { get; set; }
        public string OwnerProfessionTranslateTUR { get; set; }
        public string TitleKey { get; set; }
        public string TitleTranslateAZE { get; set; }
        public string TitleTranslateENG { get; set; }
        public string TitleTranslateRUS { get; set; }
        public string TitleTranslateTUR { get; set; }
        public string SubtitleKey { get; set; }
        public string SubtitleAZE { get; set; }
        public string SubtitleENG { get; set; }
        public string SubtitleTUR { get; set; }
        public string SubtitleRUS { get; set; }
        public string PreviewDescriptionKey { get; set; }
        public string PreviewDescriptionTranslateAZE { get; set; }
        public string PreviewDescriptionTranslateRUS { get; set; }
        public string PreviewDescriptionTranslateENG { get; set; }
        public string PreviewDescriptionTranslateTUR { get; set; }
        public string ContentHtmlRawKey { get; set; }
        public string ContentHtmlRawTranslateAZE { get; set; }
        public string ContentHtmlRawTranslateRUS { get; set; }
        public string ContentHtmlRawTranslateENG { get; set; }
        public string ContentHtmlRawTranslateTUR { get; set; }
        public string OverviewHtmlRawKey { get; set; }
        public PostScreenType ScreenType { get; set; }

        public long UserId { get; set; }

        public GetBlogCategoryDto BlogCategory { get; set; }
        public List<GetTagBlogDto> TagBlogs { get; set; }
        public GetUserDto User { get; set; }
    }
}
