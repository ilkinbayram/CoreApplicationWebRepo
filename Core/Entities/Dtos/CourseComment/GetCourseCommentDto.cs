using Core.Entities.Abstract;
using Core.Entities.Dtos.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.CourseComment
{
    public class GetCourseCommentDto : IBaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public string OwnerEmail { get; set; }
        public string CommentContent { get; set; }

        public long CourseId { get; set; }

        public GetCourseDto Course { get; set; }
    }
}
