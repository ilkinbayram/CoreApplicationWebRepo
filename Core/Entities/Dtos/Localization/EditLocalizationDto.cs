using Core.Entities.Dtos.Base;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.Localization
{
    public class EditLocalizationDto : BaseDto
    {
        public EditLocalizationDto()
        {
            ModelType = ProjectModelType.Localization;
        }
        public string Key { get; set; }
        public string Translate_Ru { get; set; }
        public string Translate_Az { get; set; }
        public string Translate_En { get; set; }
        public string Translate_Tr { get; set; }
    }
}
