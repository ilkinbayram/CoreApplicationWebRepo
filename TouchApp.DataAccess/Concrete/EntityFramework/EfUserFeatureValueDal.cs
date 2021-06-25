using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserFeatureValueDal : EfEntityRepositoryBase<UserFeatureValue, ApplicationDbContext>, IUserFeatureValueDal
    {
        public EfUserFeatureValueDal(ApplicationDbContext context) : base(context)
        {
        }

        public void AddUserFeature(UserFeatureValue mappingfeature)
        {
            Context.Set<UserFeatureValue>().Add(mappingfeature);
        }
    }
}
