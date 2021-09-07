﻿using Core.Entities.Concrete.Base;
using Core.Resources.Enums;

namespace Core.Entities.Concrete
{
    public class Phrase : BaseEntity, IEntity
    {
        public Phrase()
        {
            ModelType = ProjectModelType.Phrase;
        }

        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
        public string CaptionSource { get; set; }
        public string ProfessionKey { get; set; }
        public string ContentKey { get; set; }
        public string TitleKey { get; set; }
    }
}
