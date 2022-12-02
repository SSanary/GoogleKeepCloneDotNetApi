using GoogleKeepBackendClone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoogleKeepBackendClone.Configuration
{
    public class UserConfiguration
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x =>x.Name).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Surname).IsRequired();
            builder.HasMany<Note>(x => x.Notes).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasMany<Tag>(x => x.Tags).WithOne(x => x.User).HasForeignKey(x => x.UserId);    
            builder.HasMany<Reminder>(x => x.Reminders).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
