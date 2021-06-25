namespace Core.Entities.Dtos.Category
{
    public class CategoryFeatureDto
    {
        public long Id { get; set; }
        /// <summary>
        /// fieldin idsi
        /// </summary>
        public long? FeatureId { get; set; }
        public long? CategoryId { get; set; }
    }
}
