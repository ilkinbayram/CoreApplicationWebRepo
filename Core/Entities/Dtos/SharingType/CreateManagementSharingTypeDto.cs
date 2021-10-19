using Core.Entities.Dtos.Base;
using Core.Resources.Enums;
using Core.Utilities.UsableModel;
using System.Collections.Generic;

namespace Core.Entities.Dtos.SharingType
{
    public class CreateManagementSharingTypeDto : BaseDto
    {
        public CreateManagementSharingTypeDto()
        {
            ResponseMessages = new List<AlertResult>();
            ModelType = ProjectModelType.SharingType;
        }

        public string NameKey { get; set; }
        public string NameTranslateAZE { get; set; }
        public string NameTranslateRUS { get; set; }
        public string NameTranslateENG { get; set; }
        public string NameTranslateTUR { get; set; }
        public string AbriveatureClass { get; set; }

        public List<AlertResult> ResponseMessages { get; set; }
    }
}
