using Core.Entities.Abstract;
using Core.Entities.Dtos.SocialMedia;
using Core.Entities.Dtos.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.TeacherSocialMedia
{
    public class GetTeacherSocialMediaDto : BaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public string RedirectUrl { get; set; }

        public long TeacherId { get; set; }
        public long SocialMediaId { get; set; }

        public GetTeacherDto Teacher { get; set; }
        public GetSocialMediaDto SocialMedia { get; set; }

    }
}
