using Core.Entities.Dtos.Base;
using Core.Resources.Enums;



namespace Core.Entities.Dtos.Tag
{
    public class GetTagDto : BaseDto
    {
        public GetTagDto()
        {
            ModelType = ProjectModelType.Tag;
        }

        public string Name { get; set; }
        public TagTypeEnum TagType { get; set; }
    }
}
