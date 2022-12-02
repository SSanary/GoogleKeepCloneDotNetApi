using GoogleKeepBackendClone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Azure.Core.HttpHeader;

namespace GoogleKeepBackendClone.Configuration
{
    public class TagConfiguration
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TagName);
            builder.Property(x => x.IsDeleted).HasDefaultValue(0);
            builder.Property(x => x.UserId);
        }
    }
}
