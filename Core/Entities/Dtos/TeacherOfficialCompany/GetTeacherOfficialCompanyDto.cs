using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.OfficialCompany;
using Core.Entities.Dtos.Teacher;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.TeacherOfficialCompany
{
    public class GetTeacherOfficialCompanyDto : BaseDto
    {
        public GetTeacherOfficialCompanyDto()
        {
            ModelType = ProjectModelType.TeacherOfficialCompany;
        }

        public string WorkSectionKey { get; set; }
        public string PositionKey { get; set; }

        public long TeacherId { get; set; }
        public long OfficialCompanyId { get; set; }

        public virtual GetTeacherDto Teacher { get; set; }
        public virtual GetOfficialCompanyDto OfficialCompany { get; set; }
    }
}
