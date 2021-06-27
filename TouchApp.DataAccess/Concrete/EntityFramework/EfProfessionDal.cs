﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfProfessionDal : EfEntityRepositoryBase<Profession, ApplicationDbContext>, IProfessionDal
    {
        public EfProfessionDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
