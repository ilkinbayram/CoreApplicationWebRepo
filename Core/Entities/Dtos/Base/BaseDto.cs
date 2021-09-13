using System;

using Core.Resources.Enums;



namespace Core.Entities.Dtos.Base
{
    public class BaseDto : IDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }
        public ProjectModelType ModelType { get; set; }
    }
}
