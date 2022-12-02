using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GoogleKeepBackendClone.Models;


namespace GoogleKeepBackendClone.Configuration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)  
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsDeleted).HasDefaultValue(0);
            builder.Property(x => x.IsAchived).HasDefaultValue(0);
            builder.Property(x => x.LastChangeTime);
            builder.Property(x => x.CreateTime);
            builder.Property(x => x.Context);
            builder.Property(x => x.TagId);
            builder.Property(x => x.UserId);
            //builder.HasOne<User>(x => x.User).WithMany(x => x.Notes).HasForeignKey(x => x.User.Id);
            //builder.HasOne<Tag>(x => x.Tag).WithMany(x => x.Notes).HasForeignKey(x => x.Tag.Id);

        }
    }
}