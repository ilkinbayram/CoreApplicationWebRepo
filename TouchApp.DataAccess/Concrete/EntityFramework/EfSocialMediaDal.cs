using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfSocialMediaDal : EfEntityRepositoryBase<SocialMedia, ApplicationDbContext>, ISocialMediaDal
    {
        public EfSocialMediaDal(ApplicationDbContext context) : base(context)
        {
        }

        public List<SocialMedia> GetAllWithRelations(Expression<Func<SocialMedia, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return filter == null ?
                Context.SocialMedias.
                Include(x => x.UserSocialMedias).ThenInclude(x => x.SocialMedia).
                Include(x => x.TeacherSocialMedias).ThenInclude(x => x.SocialMedia).
                Include(x => x.UserSocialMedias).ThenInclude(x => x.User).
                Include(x => x.TeacherSocialMedias).ThenInclude(x => x.Teacher).ToList() :
                Context.SocialMedias.
                Include(x => x.UserSocialMedias).ThenInclude(x => x.SocialMedia).
                Include(x => x.TeacherSocialMedias).ThenInclude(x => x.SocialMedia).
                Include(x => x.UserSocialMedias).ThenInclude(x => x.User).
                Include(x => x.TeacherSocialMedias).ThenInclude(x => x.Teacher).Where(filter).ToList();
        }

        public SocialMedia GetWithRelations(Expression<Func<SocialMedia, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return Context.SocialMedias.
                Include(x => x.UserSocialMedias).ThenInclude(x => x.SocialMedia).
                Include(x => x.TeacherSocialMedias).ThenInclude(x => x.SocialMedia).
                Include(x => x.UserSocialMedias).ThenInclude(x => x.User).
                Include(x => x.TeacherSocialMedias).ThenInclude(x => x.Teacher).FirstOrDefault(filter);
        }
    }
}
