using Core.Entities.Abstract;
using System;

namespace Core.Entities.Dtos.Phrase
{
    public class GetPhraseDto : IBaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
        public string CaptionSource { get; set; }
        public string ProfessionKey { get; set; }
        public string ContentKey { get; set; }
        public string TitleKey { get; set; }
    }
}
