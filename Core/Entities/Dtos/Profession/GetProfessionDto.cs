using Core.Entities.Abstract;
using Core.Entities.Dtos.Teacher;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.Profession
{
    public class GetProfessionDto : IBaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

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
