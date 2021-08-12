using Core.Entities.Abstract;
using System;

namespace Core.Entities.Dtos.Teacher
{
    public class GetTeacherDto : IBaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }
    }
}
