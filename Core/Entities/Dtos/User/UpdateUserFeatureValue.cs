namespace Core.Entities.Dtos.User
{
    public class UpdateUserFeatureValue
    {
        public long Id { get; set; }
        public long CategoryFeatureId { get; set; }
        public long FeatureValueId { get; set; }
    }
}
