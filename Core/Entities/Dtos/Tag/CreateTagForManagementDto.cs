using Core.Entities.Abstract;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.Tag
{
    public class CreateTagForManagementDto : BaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public string Name { get; set; }
        public TagTypeEnum TagType { get; set; }
    }
}
