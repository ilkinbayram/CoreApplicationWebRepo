using System;

namespace Core.Entities.Dtos.Category
{
    public class CategoryClientDto
    {
        public long Id { get; set; }
        /// <summary>
        /// Üst kateqoriya İd-si
        /// </summary>
        public Nullable<int> ParentCategoryId { get; set; }
        /// <summary>
        /// Esas sehifede gosterilsinmi ?
        /// </summary>
        public bool ShowInHomePage { get; set; }
        public string Banner { get; set; }
        public string BannerCloudinaryUrl { get; set; }
    }
}
