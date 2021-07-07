using Microsoft.EntityFrameworkCore;
using Core.Entities.Concrete;
using Core.Entities.Dtos.User;
using TouchApp.DataAccess.Concrete.EntityFramework.Configurations;

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
            modelBuilder.ApplyConfiguration(new HomeMetaTagConfiguration());
            modelBuilder.ApplyConfiguration(new HomeMetaTagGalleryConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new OperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserOperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new LocalizationConfiguration());
            modelBuilder.ApplyConfiguration(new MediaConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessionConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new SharingTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TagPostsConfiguration());
            modelBuilder.ApplyConfiguration(new SharingTypePostConfiguration());
            modelBuilder.ApplyConfiguration(new SocialMediaConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherInfoConfiguration());
            modelBuilder.ApplyConfiguration(new UserSocialMediaConfiguration());
            modelBuilder.ApplyConfiguration(new RoutingConfiguration());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<HomeMetaTagGallery> HomeMetaTagGalleries { get; set; }
        public DbSet<HomeMetaTag> HomeMetaTags { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Localization> Localizations { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Post> Posts { get; set; }
        // public DbSet<Phrase> Phrases { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SharingType> SharingTypes { get; set; }
        public DbSet<SharingTypePost> SharingTypePosts { get; set; }
        public DbSet<TagPosts> TagPosts { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<TeacherInfo> TeacherInfos { get; set; }
        public DbSet<UserSocialMedia> UserSocialMedias { get; set; }
        public DbSet<Routing> Routings { get; set; }
    }
}
