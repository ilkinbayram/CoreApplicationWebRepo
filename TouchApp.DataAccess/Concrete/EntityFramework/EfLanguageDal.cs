﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfLanguageDal : EfEntityRepositoryBase<Language, ApplicationDbContext>, ILanguageDal
    {
        public EfLanguageDal(ApplicationDbContext applicationContext) : base(applicationContext)
        {
        }
    }
}
