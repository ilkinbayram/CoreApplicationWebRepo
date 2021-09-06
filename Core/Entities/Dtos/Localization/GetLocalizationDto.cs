using Core.Entities.Dtos.Base;

namespace Core.Entities.Dtos.Localization
{
    public class GetLocalizationDto : BaseDto
    {
        public string Key { get; set; }
        public string Translate_Ru { get; set; }
        public string Translate_Az { get; set; }
        public string Translate_En { get; set; }
        public string Translate_Tr { get; set; }
    }
}
