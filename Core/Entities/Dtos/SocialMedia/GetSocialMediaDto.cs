using Core.Entities.Abstract;
using Core.Entities.Dtos.TeacherSocialMedia;
using Core.Entities.Dtos.UserSocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.SocialMedia
{
    public class GetSocialMediaDto : BaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public string NameSocial { get; set; }
        public string Uri { get; set; }
        public string IconSource { get; set; }

        public List<GetUserSocialMediaDto> UserSocialMedias { get; set; }
        public List<GetTeacherSocialMediaDto> TeacherSocialMedias { get; set; }
    }
}
