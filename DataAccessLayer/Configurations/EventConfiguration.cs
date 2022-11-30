using Entities.Identity;
using Entities.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);
        //builder.HasMany<Event>(e => e.ConnectionWithUsers)
        //    .WithMany<User>(u => u.ConnectionWithEvents);
    }
}