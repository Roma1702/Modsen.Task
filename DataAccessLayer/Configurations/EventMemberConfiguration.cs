using Entities.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class EventMemberConfiguration : IEntityTypeConfiguration<EventMember>
    {
        public void Configure(EntityTypeBuilder<EventMember> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Event)
                .WithMany(e => e.EventMembers)
                .HasForeignKey(e => e.EventId);

            builder.HasOne(e => e.User)
                .WithMany(e => e.EventMembers)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.EventRole)
                .WithMany(e => e.EventMembers)
                .HasForeignKey(e => e.RoleId);
        }
    }
}
