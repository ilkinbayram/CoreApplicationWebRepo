using Core.Entities.Concrete.Base;
using Core.Resources.Enums;



namespace Core.Entities.Concrete
{
    public class TeacherOfficialCompany : BaseEntity, IEntity
    {
        public TeacherOfficialCompany()
        {
            ModelType = ProjectModelType.TeacherOfficialCompany;
        }

        public string WorkSectionKey { get; set; }
        public string PositionKey { get; set; }

        public long TeacherId { get; set; }
        public long OfficialCompanyId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual OfficialCompany OfficialCompany { get; set; }
    }
}
