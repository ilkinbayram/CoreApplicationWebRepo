using Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public interface IDto
    {
        long Id { get; set; }
        string Created_by { get; set; }
        DateTime Created_at { get; set; }
        ProjectModelType ModelType { get; set; }
    }
}
