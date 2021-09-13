using System.Collections.Generic;

using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.TeacherOfficialCompany;
using Core.Resources.Enums;



namespace Core.Entities.Dtos.OfficialCompany
{
    public class GetOfficialCompanyDto : BaseDto
    {
        public GetOfficialCompanyDto()
        {
            ModelType = ProjectModelType.OfficialCompany;
        }

        public string WebUrl { get; set; }
        public string Location { get; set; }
        public string NameKey { get; set; }
        public string DescriptionKey { get; set; }

        public virtual List<GetTeacherOfficialCompanyDto> TeacherOfficialCompanies { get; set; }
    }
}
