﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfHomeMetaTagGalleryDal : EfEntityRepositoryBase<HomeMetaTagGallery, ApplicationDbContext>, IHomeMetaTagGalleryDal
    {
        public EfHomeMetaTagGalleryDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
