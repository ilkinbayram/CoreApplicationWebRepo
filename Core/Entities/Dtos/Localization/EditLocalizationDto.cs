using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.Localization
{
    public class EditLocalizationDto : IBaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public string Key { get; set; }
        public string Translate { get; set; }
        public long Project_oid { get; set; }
        public byte Lang_oid { get; set; }
    }
}
