using Core.Entities.Dtos.Base;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.Tag
{
    public class CreateTagForManagementDto : BaseDto
    {
        public CreateTagForManagementDto()
        {
            ModelType = ProjectModelType.Tag;
        }

        public string Name { get; set; }
        public TagTypeEnum TagType { get; set; }
    }
}
