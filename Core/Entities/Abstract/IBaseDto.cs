﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public interface IBaseDto
    {
        long Id { get; set; }
        string Created_by { get; set; }
        DateTime Created_at { get; set; }

    }
}
