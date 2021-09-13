using System.Collections.Generic;

using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.SharingTypeMedia;
using Core.Resources.Enums;


namespace Core.Entities.Dtos.SharingType
{
    public class GetSharingTypeDto : BaseDto
    {
        public GetSharingTypeDto()
        {
            ModelType = ProjectModelType.SharingType;
        }
        public string NameKey { get; set; }

        public List<GetSharingTypeMediaDto> SharingTypeMedias { get; set; }
    }
}
