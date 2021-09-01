using Core.Entities.Abstract;
using Core.Entities.Dtos.SocialMedia;
using Core.Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.UserSocialMedia
{
    public class GetUserSocialMediaDto : IBaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public string RedirectUrl { get; set; }

        public long UserId { get; set; }
        public long SocialMediaId { get; set; }

        public GetUserDto User { get; set; }
        public GetSocialMediaDto SocialMedia { get; set; }
    }
}
