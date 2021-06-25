using Microsoft.EntityFrameworkCore;
using Core.Entities.Concrete;
using Core.Entities.Dtos.User;
using DataAccess.Concrete.EntityFramework.Configurations;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserFeatureValueConfiguration());
            modelBuilder.ApplyConfiguration(new UserLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new HomeMetaTagConfiguration());
            modelBuilder.ApplyConfiguration(new HomeMetaTagGalleryConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new OperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserOperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<CategoryLanguage> CategoryLanguages { get; set; }
        public DbSet<UserLanguage> ProductLanguages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureLanguage> FeatureLanguages { get; set; }
        public DbSet<CategoryFeature> CategoryFeatures { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionLanguage> SectionLanguages { get; set; }
        public DbSet<HomeMetaTagGallery> HomeMetaTagGalleries { get; set; }
        public DbSet<HomeMetaTag> HomeMetaTags { get; set; }
        public DbSet<HomeMetaTagSection> HomeMetaTagSections { get; set; }
        public DbSet<HomeMetaTagLanguage> HomeMetaTagLanguages { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageLanguage> MessageLanguages { get; set; }
        public DbSet<UserFeatureValue> UserFeatureValues { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<FeatureValue> FeatureValues { get; set; }
        public DbSet<FeatureValueLanguage> FeatureValueLanguages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GetSubCategoriesDAO> GetSubCategoriesView { get; set; }
        public DbSet<SearchCelebrityDAO> SearchCelebritiesView { get; set; }
    }
}
