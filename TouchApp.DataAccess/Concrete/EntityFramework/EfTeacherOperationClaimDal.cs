﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfTeacherOperationClaimDal : EfEntityRepositoryBase<TeacherOperationClaim, ApplicationDbContext>, ITeacherOperationClaimDal
    {
        public EfTeacherOperationClaimDal(ApplicationDbContext context):base(context)
        {
        }
    }
}