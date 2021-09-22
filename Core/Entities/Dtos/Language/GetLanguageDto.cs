using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Course;
using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Entities.Dtos.Language
{
    public class GetLanguageDto : BaseDto
    {
        public GetLanguageDto()
        {
            ModelType = ProjectModelType.Language;
        }

        public string NameKey { get; set; }
        public string FlagIconSource { get; set; }
        public string NameAbr { get; set; }


        public virtual List<GetCourseDto> Courses { get; set; }
    }
}
