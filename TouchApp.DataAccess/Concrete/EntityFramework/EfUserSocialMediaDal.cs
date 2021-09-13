﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfUserSocialMediaDal : EfEntityRepositoryBase<UserSocialMedia, ApplicationDbContext>, IUserSocialMediaDal
    {
        public EfUserSocialMediaDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
