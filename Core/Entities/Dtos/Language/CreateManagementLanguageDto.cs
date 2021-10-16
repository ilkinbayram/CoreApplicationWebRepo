using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Course;
using Core.Resources.Enums;
using Core.Utilities.UsableModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Entities.Dtos.Language
{
    public class CreateManagementLanguageDto : BaseDto
    {
        public CreateManagementLanguageDto()
        {
            ModelType = ProjectModelType.Language;
            Created_at = DateTime.Now;
            Created_by = "System";

            ResponseMessages = new List<AlertResult>();
        }
        public short Language_oid { get; set; }

        public string NameKey { get; set; }
        public string NameTranslateAZE { get; set; }
        public string NameTranslateTUR { get; set; }
        public string NameTranslateENG { get; set; }
        public string NameTranslateRUS { get; set; }
        public IFormFile FlagIconFile { get; set; }
        public string FlagIconSource { get; set; }
        public string NameAbr { get; set; }

        public List<SelectListItem> LangAbriveatures => 
            Enum.GetValues<LanguageOidContainerEnum>().Cast<short>().ToList().Select(x => new SelectListItem
            {
                Value = x.ToString(),
                Text = Enum.GetName(typeof(LanguageOidContainerEnum), x)
            }).ToList();

        public List<AlertResult> ResponseMessages { get; set; }

        public virtual List<CreateManagementCourseDto> Courses { get; set; }
    }
}
