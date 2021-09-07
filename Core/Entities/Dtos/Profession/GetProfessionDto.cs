using System;
using System.Collections.Generic;
using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Teacher;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.Profession
{
    public class GetProfessionDto : BaseDto
    {
        public GetProfessionDto()
        {
            ModelType = ProjectModelType.Profession;
        }
        public string NameKey { get; set; }
        public string SubnameKey { get; set; }
        public string ProfDescKey { get; set; }
        public DateTime StartProfession { get; set; }
        public ProfessionDegree ProfessionDegree { get; set; }
        public string CurrentCompanyKey { get; set; }
        public string CurrentPositionAtCompanyKey { get; set; }
        public long? ParentProfessionId { get; set; }


        public HashSet<GetProfessionDto> SubProfession { get; set; }
        public GetProfessionDto ParentProfession { get; set; }
        public List<GetTeacherDto> Teachers { get; set; }
    }
}
