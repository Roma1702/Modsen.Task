using DataAccessLayer.Abstractions.Interfaces;

namespace DataAccessLayer.Data;

public class DbInitializer : IDbInitializer
{
    private readonly ApplicationContext _context;

    public DbInitializer(ApplicationContext context)
    {
        _context = context;
    }
    public void Initialize()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        _context.Roles.AddRange(FakeData.Roles);
        _context.SaveChanges();

        _context.Users.AddRange(FakeData.Users);
        _context.SaveChanges();

        _context.Events?.AddRange(FakeData.Events);
        _context.SaveChanges();

        _context.EventRoles?.AddRange(FakeData.EventRoles);
        _context.SaveChanges();

        _context.EventMembers?.AddRange(FakeData.EventMembers);
        _context.SaveChanges();

        _context.UserRoles?.AddRange(FakeData.UserRoles);
        _context.SaveChanges();
    }
}