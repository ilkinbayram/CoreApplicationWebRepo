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
        public string TranslateRUS { get; set; }
        public string TranslateAZE { get; set; }
        public string TranslateENG { get; set; }
        public string TranslateTUR { get; set; }
        public short Project_oid { get; set; }
        public short Lang_oid { get; set; }
    }
}
