namespace Core.Entities.Dtos.User
{
    public class GetClientDto : IDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
