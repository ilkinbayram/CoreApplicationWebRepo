using System.Collections.Generic;
using Core.Entities.Dtos.User;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IAdminService
    {
        IDataResult<ICollection<GetAdminDto>> GetAll();
    }
}
