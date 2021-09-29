using System.Collections.Generic;

using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.SharingTypeMedia;
using Core.Resources.Enums;




namespace Core.Entities.Dtos.Media
{
    public class GetMediaDto : BaseDto
    {
        public GetMediaDto()
        {
            ModelType = ProjectModelType.Media;
        }
        public string Source { get; set; }
        public string AltrKey { get; set; }
        public string UniqueParentToken { get; set; }
        public string SharingTypeFilterConcat { get; set; }
        public MediaType MediaType { get; set; }

        public List<GetSharingTypeMediaDto> SharingTypeMedias { get; set; }
    }
}
