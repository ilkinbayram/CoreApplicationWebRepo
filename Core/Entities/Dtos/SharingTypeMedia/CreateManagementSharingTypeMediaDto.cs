﻿using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Media;
using Core.Entities.Dtos.SharingType;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.SharingTypeMedia
{
    public class CreateManagementSharingTypeMediaDto : BaseDto
    {
        public CreateManagementSharingTypeMediaDto()
        {
            ModelType = ProjectModelType.SharingTypeMedia;
        }

        public long MediaId { get; set; }
        public long SharingTypeId { get; set; }

        public CreateManagementMediaDto Media { get; set; }
        public GetSharingTypeDto SharingType { get; set; }
    }
}