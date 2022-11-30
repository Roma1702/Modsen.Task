using Entities.Identity;
using Entities.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //builder.HasKey(u => u.Id);
        //builder.HasMany<User>(u => u.ConnectionWithEvents)
        //    .WithMany<Event>(e => e.ConnectionWithUsers);
    }
}