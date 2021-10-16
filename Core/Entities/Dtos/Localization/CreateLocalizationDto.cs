using Core.Entities.Dtos.Base;
using Core.Resources.Enums;
using Core.Utilities.UsableModel;
using System;
using System.Collections.Generic;

namespace Core.Entities.Dtos.Localization
{
    public class CreateLocalizationDto : BaseDto
    {
        public CreateLocalizationDto()
        {
            ModelType = ProjectModelType.Localization;
            Created_at = DateTime.Now;
            Created_by = "System";

            ResponseMessages = new List<AlertResult>();
        }
        public string Key { get; set; }
        public string TranslateRUS { get; set; }
        public string TranslateAZE { get; set; }
        public string TranslateENG { get; set; }
        public string TranslateTUR { get; set; }

        public List<AlertResult> ResponseMessages { get; set; }
    }
}
