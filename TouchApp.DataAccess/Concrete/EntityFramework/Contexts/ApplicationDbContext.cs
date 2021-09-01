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
            modelBuilder.ApplyConfiguration(new SliderConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new OperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserOperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserCourseConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CourseCommentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseServiceConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessionCourseCategoryConfiguration());

            modelBuilder.ApplyConfiguration(new LocalizationConfiguration());
            modelBuilder.ApplyConfiguration(new MediaConfiguration());
            modelBuilder.ApplyConfiguration(new PhraseConfiguration());
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new BlogCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessionConfiguration());
            modelBuilder.ApplyConfiguration(new SharingTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SharingTypeMediaConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new TagBlogConfiguration());
            modelBuilder.ApplyConfiguration(new SocialMediaConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherCourseConfiguration());
            modelBuilder.ApplyConfiguration(new UserSocialMediaConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherSocialMediaConfiguration());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseService> CourseServices { get; set; }
        public DbSet<CourseComment> CourseComments { get; set; }
        public DbSet<ProfessionCourseCategory> ProfessionCourseCategories { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }

        public DbSet<Localization> Localizations { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Phrase> Phrases { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<SharingType> SharingTypes { get; set; }
        public DbSet<SharingTypeMedia> SharingTypeMedias { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagBlog> TagBlogs { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<UserSocialMedia> UserSocialMedias { get; set; }
        public DbSet<TeacherSocialMedia> TeacherSocialMedias { get; set; }
    }
}
