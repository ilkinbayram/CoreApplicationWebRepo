using System;
using System.Collections.Generic;
using Core.Entities.Concrete.Base;
using Core.Resources.Enums;

namespace Core.Entities.Concrete
{
    public class User : BaseEntity, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProfilePhotoPath { get; set; }
        public string WallpaperPath { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string PhoneNumberPrefix { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public AccountType AccountType { get; set; }
        public decimal? Rate { get; set; }
        public int? RateCount { get; set; }
        public string Biography { get; set; }
        public decimal? UnitPrice { get; set; }
        public string PreviewMoviePath { get; set; }

        public long? CategoryId { get; set; }
        public bool ShowInHomePage { get; set; }
        public string SecurityToken { get; set; }

        public virtual Category Category { get; set; }
        public virtual IEnumerable<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual IEnumerable<Order> UserOrders { get; set; }
        public virtual IEnumerable<Order> FamousOrders { get; set; }

        public virtual IEnumerable<Rate> UserRates { get; set; }
        public virtual IEnumerable<Rate> FamousRates { get; set; }

        public virtual IEnumerable<UserLanguage> UserLanguages { get; set; }
        public virtual IEnumerable<UserFeatureValue> UserFeatureValues { get; set; }
    }
}
