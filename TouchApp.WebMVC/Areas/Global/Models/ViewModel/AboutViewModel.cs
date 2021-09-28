using Core.Entities.Dtos.Teacher;
using System.Collections.Generic;

namespace TouchApp.WebMVC.Areas.Global.Models.ViewModel
{
    public class AboutViewModel
    {
        public List<GetTeacherDto> Teachers { get; set; }
    }
}
