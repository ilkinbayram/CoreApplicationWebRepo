using System;

namespace Core.Entities.Dtos
{
    public class UserForRegisterDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string  Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool  IsAgree { get; set; }
        public DateTime? Birthday { get; set; }
    }
}