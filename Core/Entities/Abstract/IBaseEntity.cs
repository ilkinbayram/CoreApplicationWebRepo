using System;

using Core.Resources.Enums;




namespace Core.Entities.Abstract
{
    public interface IBaseEntity
    {
        long Id { get; set; }
        string Created_by { get; set; }
        DateTime? Created_at { get; set; }
        ProjectModelType ModelType { get; set; }
    }
}
