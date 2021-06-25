namespace Core.Entities.Concrete
{
    public class HomeMetaTagGallery : IEntity
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public long Order { get; set; }
        public string Alt { get; set; }
        public bool IsActive { get; set; }
        public long HomeMetaTagId { get; set; }
        public virtual HomeMetaTag HomeMetaTag { get; set; }
    }
}
