using Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public interface IUserBaseEntity
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string ProfilePhotoPath { get; set; }
        string WallpaperPath { get; set; }
        byte[] PasswordSalt { get; set; }
        byte[] PasswordHash { get; set; }
        string PhoneNumberPrefix { get; set; }
        string PhoneNumber { get; set; }
        DateTime? Birthday { get; set; }
        Gender Gender { get; set; }
        string BiographyKey { get; set; }
        string SecurityToken { get; set; }
    }
}
