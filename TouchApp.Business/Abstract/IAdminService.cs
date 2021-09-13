using Core.Entities.Dtos.User;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace TouchApp.Business.Abstract
{
    public interface IAdminService
    {
        IDataResult<ICollection<GetAdminDto>> GetAll();
    }
}
