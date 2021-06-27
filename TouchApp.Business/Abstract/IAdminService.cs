using System.Collections.Generic;
using Core.Entities.Dtos.User;
using Core.Utilities.Results;

namespace TouchApp.Business.Abstract
{
    public interface IAdminService
    {
        IDataResult<ICollection<GetAdminDto>> GetAll();
    }
}
