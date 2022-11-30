using Entities.Identity;
using Entities.Implementation;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Data;

public static class FakeData
{
    public static ICollection<Event> Events = new List<Event>
    {
        new Event
        {
            Name = string.Empty,
            Description = string.Empty,
            Plan = string.Empty,
            Place = string.Empty,
            MeetupDate = DateTimeOffset.Now.AddHours(4)
        }
    };

    public static ICollection<IdentityRole<Guid>> Roles = new List<IdentityRole<Guid>>
    {
        new IdentityRole<Guid>("admin")
    };
    public static ICollection<User> Users = new List<User>
    {
        new User
        {
            Email = "admin@aaa.com",
            Age = 20,
            NormalizedEmail = "admin@aaa.com",
            UserName = "admin@aaa.com",
            NormalizedUserName = "admin@aaa.com",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEHOnF+aiX0aOAcQTNVLA4BNSmJ3aJVLcgq4JtmUakxr/xYQs9CPHyZwRJ9iK2MJfQg==", // !QAZ2wsx
            SecurityStamp = Guid.NewGuid().ToString("D")
        }
    };
    public static ICollection<UserConnectionWithEvent> UserConnectionsWithEvent = new List<UserConnectionWithEvent>
    {
        new UserConnectionWithEvent
        {
            User = Users.FirstOrDefault(),
            Event = Events.FirstOrDefault()
        }
    };
}