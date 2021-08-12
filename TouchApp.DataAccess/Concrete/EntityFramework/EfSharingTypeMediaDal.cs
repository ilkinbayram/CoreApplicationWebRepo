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
    public class EfSharingTypeMediaDal : EfEntityRepositoryBase<SharingTypeMedia, ApplicationDbContext>, ISharingTypeMediaDal
    {
        public EfSharingTypeMediaDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}