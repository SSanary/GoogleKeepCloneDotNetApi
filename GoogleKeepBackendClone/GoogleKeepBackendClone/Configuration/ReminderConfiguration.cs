using GoogleKeepBackendClone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoogleKeepBackendClone.Configuration
{
    public class ReminderConfiguration
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsDeleted).HasDefaultValue(0);
            builder.Property(x => x.IsAchived).HasDefaultValue(0);
            builder.Property(x => x.LastChangeTime);
            builder.Property(x => x.CreateTime);
            builder.Property(x => x.Context);
            builder.Property(x => x.AlarmTime);
            builder.HasOne<User>(x => x.User).WithMany(x => x.Reminders).HasForeignKey(x => x.User.Id);
        }
    }
}
