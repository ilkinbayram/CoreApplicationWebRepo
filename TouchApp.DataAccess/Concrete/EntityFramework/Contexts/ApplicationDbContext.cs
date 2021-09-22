using Microsoft.EntityFrameworkCore;
using Core.Entities.Concrete;
using TouchApp.DataAccess.Concrete.EntityFramework.Configurations;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SliderConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new OperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserOperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherOperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new StudentOperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CourseCommentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseServiceConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessionCourseCategoryConfiguration());

            modelBuilder.ApplyConfiguration(new LocalizationConfiguration());
            modelBuilder.ApplyConfiguration(new MediaConfiguration());
            modelBuilder.ApplyConfiguration(new PhraseConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new BlogCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SharingTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SharingTypeMediaConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new TagBlogConfiguration());
            modelBuilder.ApplyConfiguration(new SocialMediaConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherCourseConfiguration());
            modelBuilder.ApplyConfiguration(new UserSocialMediaConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherSocialMediaConfiguration());

            modelBuilder.ApplyConfiguration(new AnswerVariationConfiguration());
            modelBuilder.ApplyConfiguration(new ExamConfiguration());
            modelBuilder.ApplyConfiguration(new ExamQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionResultExamConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionVariationConfiguration());
            modelBuilder.ApplyConfiguration(new ResultExamConfiguration());
            modelBuilder.ApplyConfiguration(new StudentStudyingGroupConfiguration());
            modelBuilder.ApplyConfiguration(new StudyingGroupConfiguration());
        }


        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<TeacherOperationClaim> TeacherOperationClaims { get; set; }
        public DbSet<StudentOperationClaim> StudentOperationClaims { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseService> CourseServices { get; set; }
        public DbSet<CourseComment> CourseComments { get; set; }
        public DbSet<ProfessionCourseCategory> ProfessionCourseCategories { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<AnswerVariation> AnswerVariations { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionResultExam> QuestionResultExams { get; set; }
        public DbSet<QuestionVariation> QuestionVariations { get; set; }
        public DbSet<ResultExam> ResultExams { get; set; }
        public DbSet<StudentStudyingGroup> StudentStudyingGroups { get; set; }
        public DbSet<StudyingGroup> StudyingGroups { get; set; }

        public DbSet<Localization> Localizations { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Phrase> Phrases { get; set; }
        public DbSet<Blog> Blogs { get; set; }
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
