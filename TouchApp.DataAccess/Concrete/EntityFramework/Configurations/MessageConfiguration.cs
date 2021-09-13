using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities.Concrete;


namespace TouchApp.DataAccess.Concrete.EntityFramework.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(p => p.MessageCode).IsRequired();
        }
    }
}
