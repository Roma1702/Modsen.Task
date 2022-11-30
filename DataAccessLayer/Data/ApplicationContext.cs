using DataAccessLayer.Configurations;
using Entities.Identity;
using Entities.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data;

public class ApplicationContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DbSet<Event>? Events { get; set; }
    public DbSet<UserConnectionWithEvent>? ConnectionsUserWithEvent { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new EventConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new UserConnectionWithEventConfiguration());
    }
}