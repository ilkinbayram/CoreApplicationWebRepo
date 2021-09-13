using Core.Entities.Dtos.User;
using Core.Resources.Enums;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using TouchApp.Business.Abstract;
using TouchApp.DataAccess.Abstract;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IUserDal _userDal;

        public AdminManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public IDataResult<ICollection<GetAdminDto>> GetAll()
        {
            try
            {
                var list = _userDal.GetList(f => f.AccountType == AccountType.Admin).Select(s => new GetAdminDto()
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email
                }).ToList();

                return new SuccessDataResult<ICollection<GetAdminDto>>(list);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<ICollection<GetAdminDto>>(e.Message);
            }
        }
    }
}
