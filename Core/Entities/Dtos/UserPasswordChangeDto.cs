using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos
{
    public class UserPasswordChangeDto
    {
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
    }
}
