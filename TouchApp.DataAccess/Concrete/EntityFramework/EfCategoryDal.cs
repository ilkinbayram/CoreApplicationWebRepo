using System;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Queries;
using Microsoft.Data.SqlClient;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ApplicationDbContext>, ICategoryDal
    {
        public EfCategoryDal(ApplicationDbContext applicationContext) : base(applicationContext)
        {
        }

        public Category GetCategoryById(long categoryId)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;

            var result = Context.Categories.Include(x => x.CategoryLanguages.OrderBy(x=>x.LanguageId)).ThenInclude(x => x.Language)
                                           .Include(x => x.CategoryFeatures)
                                           .FirstOrDefault(x => x.Id==categoryId && x.IsActive);
            return result;
        }

        public CategoryLanguage GetCategoryById(long categoryId, string acceptedLanguage)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;

            var result = Context.CategoryLanguages.Include(x => x.Category)
                                           .ThenInclude(x => x.CategoryFeatures)
                                           .Include(x=>x.Language)
                                           .FirstOrDefault(x => x.CategoryId == categoryId && x.Category.IsActive && x.Language.LanguageName==acceptedLanguage);
            return result;
        }

        public IEnumerable<Category> GetCategoryList(int page, int count,string key)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            if (key == null)
            {
                var result = Context.Categories.Include(x=>x.CategoryFeatures).Include(x => x.CategoryLanguages).ThenInclude(x => x.Language).Include(x => x.Children).ThenInclude(x => x.CategoryLanguages)
                                           .Include(x => x.Children).ThenInclude(x => x.Children).ThenInclude(x => x.CategoryLanguages)
                                           .Where(x => x.ParentCategoryId == null && x.IsActive).Skip(page * count - count).Take(count).OrderBy(x => x.Id).ToList();
                return result;
            }
            var r = Context.Categories.Include(x=>x.CategoryFeatures).Include(x => x.CategoryLanguages).ThenInclude(x => x.Language).Include(x => x.Children).ThenInclude(x => x.CategoryLanguages)
                                          .Include(x => x.Children).ThenInclude(x => x.Children).ThenInclude(x => x.CategoryLanguages)
                                          .Where(x => x.ParentCategoryId == null && x.IsActive  && x.CategoryLanguages.Any(z=>z.Name.ToLower().Contains(key.ToLower()))).Skip(page * count - count).Take(count).OrderBy(x => x.Id).ToList();

            return r;
        }

        public IEnumerable<CategoryLanguage> GetHomeChildCategoryList(int categoryId, string acceptedLanguage)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            var r = Context.CategoryLanguages.Include(x => x.Category).ThenInclude(x => x.Children).Where(z => z.Category.ParentCategoryId == categoryId && z.Category.ShowInHomePage && z.Category.IsActive && z.Language.LanguageName == acceptedLanguage).ToList();
            return r;
        }

        public IEnumerable<CategoryLanguage> GetHomeParentCategoryList(string acceptedLanguage)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            var r = Context.CategoryLanguages.Include(x => x.Category).ThenInclude(x=>x.Children).Where(z => z.Category.ParentCategoryId == null && z.Category.ShowInHomePage && z.Category.IsActive && z.Language.LanguageName == acceptedLanguage).ToList();
            return r;
        }

        public IEnumerable<Category> GetParentCategory()
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            
                var result = Context.Categories.Include(x => x.CategoryLanguages.OrderBy(x=>x.LanguageId)).ThenInclude(x => x.Language)
                                               .Include(x=>x.Children).Include(x=>x.CategoryFeatures)
                                               .Where(x => x.ParentCategoryId == null && x.IsActive).ToList();
                return result;
            
        }

        public IEnumerable<Category> GetSubCategories(int parentId)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;

            var result = Context.Categories.Include(x => x.CategoryLanguages).ThenInclude(x => x.Language)
                                           .Include(x=>x.Children)
                                           .Include(x=>x.CategoryFeatures)
                                           .Where(x => x.ParentCategoryId == parentId && x.IsActive).ToList();
            return result;
        }

    }
}
