using Core.Entities.Abstract;
using System;

namespace Core.Entities.Dtos.OurService
{
    public class GetCourseServiceDto : IBaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public string TitleKey { get; set; }
        public string DescriptionKey { get; set; }
        public string UniqueToken { get; set; }
        public string IconSource { get; set; }
    }
}
