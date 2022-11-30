using Entities.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class UserConnectionWithEventConfiguration : IEntityTypeConfiguration<UserConnectionWithEvent>
    {
        public void Configure(EntityTypeBuilder<UserConnectionWithEvent> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Event).WithMany(e => e.ConnectionWithUsers).HasForeignKey(e => e.EventId);
            builder.HasOne(e => e.User).WithMany(e => e.ConnectionWithEvents).HasForeignKey(e => e.UserId);
        }
    }
}
