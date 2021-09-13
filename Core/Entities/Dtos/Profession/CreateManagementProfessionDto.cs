using Core.Entities.Dtos.Base;
using Core.Resources.Enums;



namespace Core.Entities.Dtos.Profession
{
    public class CreateManagementProfessionDto : BaseDto
    {
        public CreateManagementProfessionDto()
        {
            ModelType = ProjectModelType.Profession;
        }
    }
}
