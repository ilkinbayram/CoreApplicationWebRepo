using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.BlogCategory;
using Core.Entities.Dtos.TagBlog;
using Core.Extensions;
using Core.Resources.Enums;
using Core.Utilities.UsableModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Entities.Dtos.Blog
{
    public class CreateManagementBlogDto : BaseDto
    {
        public CreateManagementBlogDto()
        {
            ModelType = ProjectModelType.Blog;
            ResponseMessages = new List<AlertResult>();
            TagBlogs = new List<CreateTagBlogManagementDto>();

            ScreenTypeSelectList = Enum.GetValues<PostScreenType>().Cast<byte>().ToList().
                               Select(x => new SelectListItem
                               {
                                   Value = x.ToString(),
                                   Text = string.Format("{0}PostScreenType.Localize", ((PostScreenType)x).ToString()).Translate()
                               }).ToList();
        }

        public string UniqueToken { get; set; }
        public string CaptionSource { get; set; }
        public IFormFile CaptionSourceFile { get; set; }
        public string TitleKey { get; set; }
        public string TitleTranslateAZE { get; set; }
        public string TitleTranslateENG { get; set; }
        public string TitleTranslateRUS { get; set; }
        public string TitleTranslateTUR { get; set; }
        public string SubtitleKey { get; set; }
        public string SubtitleTranslateAZE { get; set; }
        public string SubtitleTranslateENG { get; set; }
        public string SubtitleTranslateTUR { get; set; }
        public string SubtitleTranslateRUS { get; set; }
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
        public string TagsConcat { get; set; }
        public PostScreenType ScreenType { get; set; }
        public long BlogCategoryId { get; set; }

        public List<SelectListItem> BlogCategoryList { get; set; }
        public List<SelectListItem> ScreenTypeSelectList { get; set; }
        public CreateBlogCategoryManagementDto BlogCategory { get; set; }
        public List<CreateTagBlogManagementDto> TagBlogs { get; set; }

        public List<AlertResult> ResponseMessages { get; set; }
    }
}
