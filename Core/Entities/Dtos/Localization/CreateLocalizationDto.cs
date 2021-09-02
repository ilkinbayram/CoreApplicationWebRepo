using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.Localization
{
    public class CreateLocalizationDto : IBaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public string Key { get; set; }
        public string Translate_Ru { get; set; }
        public string Translate_Az { get; set; }
        public string Translate_En { get; set; }
        public string Translate_Tr { get; set; }
        public long Project_oid { get; set; }
    }
}
