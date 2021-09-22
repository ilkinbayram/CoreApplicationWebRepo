using Core.Entities.Dtos.Base;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.Localization
{
    public class GetLocalizationDto : BaseDto
    {
        public GetLocalizationDto()
        {
            ModelType = ProjectModelType.Localization;
        }
        public string Key { get; set; }
        public string Translate { get; set; }
        public short Project_oid { get; set; }
        public short Lang_oid { get; set; }
    }
}
