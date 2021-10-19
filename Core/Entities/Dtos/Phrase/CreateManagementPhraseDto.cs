using Microsoft.AspNetCore.Http;

using Core.Entities.Dtos.Base;
using Core.Resources.Enums;
using System.Collections.Generic;
using Core.Utilities.UsableModel;

namespace Core.Entities.Dtos.Phrase
{
    public class CreateManagementPhraseDto : BaseDto
    {
        public CreateManagementPhraseDto()
        {
            ResponseMessages = new List<AlertResult>();
            ModelType = ProjectModelType.Phrase;
        }
        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
        public IFormFile CaptionSourceFile { get; set; }
        public string CaptionSource { get; set; }
        public string ProfessionKey { get; set; }
        public string ProfessionTranslateAZE { get; set; }
        public string ProfessionTranslateRUS { get; set; }
        public string ProfessionTranslateENG { get; set; }
        public string ProfessionTranslateTUR { get; set; }
        public string ContentKey { get; set; }
        public string ContentTranslateAZE { get; set; }
        public string ContentTranslateTUR { get; set; }
        public string ContentTranslateENG { get; set; }
        public string ContentTranslateRUS { get; set; }
        public string TitleKey { get; set; }
        public string TitleTranslateAZE { get; set; }
        public string TitleTranslateRUS { get; set; }
        public string TitleTranslateENG { get; set; }
        public string TitleTranslateTUR { get; set; }

        public List<AlertResult> ResponseMessages { get; set; }
    }
}
