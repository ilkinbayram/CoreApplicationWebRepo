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
        public DbSet<UserLanguage> ProductLanguages { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<HomeMetaTagGallery> HomeMetaTagGalleries { get; set; }
        public DbSet<HomeMetaTag> HomeMetaTags { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
