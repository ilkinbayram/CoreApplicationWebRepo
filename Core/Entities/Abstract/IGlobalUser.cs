using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public interface IGlobalUser
    {
        string Profession { get; set; }
        string SubProfession { get; set; }
        string ProfessionDescription { get; set; }
    }
}
