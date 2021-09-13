using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities.Concrete;


namespace TouchApp.DataAccess.Concrete.EntityFramework.Configurations
{
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.ToTable("Sliders");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(p => p.TitleKey).HasColumnType("nvarchar").HasMaxLength(500).IsRequired();
            builder.Property(p => p.SubTitleKey).HasColumnType("nvarchar").HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(true);
        }
    }
}

