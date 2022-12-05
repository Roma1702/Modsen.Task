using Entities.Identity;
using Entities.Implementation;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Data;

public static class FakeData
{
    public static ICollection<IdentityRole<Guid>> Roles = new List<IdentityRole<Guid>>
    {
        new IdentityRole<Guid>
        {
            Id = Guid.NewGuid(),
            Name = "admin",
            NormalizedName = "admin"
        }
    };

    public static ICollection<User> Users = new List<User>
    {
        new User
        {
            Id = Guid.NewGuid(),
            Email = "admin@aaa.com",
            Age = 20,
            NormalizedEmail = "admin@aaa.com",
            UserName = "admin@aaa.com",
            NormalizedUserName = "admin@aaa.com",
            EmailConfirmed = true,
            PasswordHash =
                "AQAAAAEAACcQAAAAEHOnF+aiX0aOAcQTNVLA4BNSmJ3aJVLcgq4JtmUakxr/xYQs9CPHyZwRJ9iK2MJfQg==", // !QAZ2wsx
            SecurityStamp = Guid.NewGuid().ToString("D"),
        }
    };

    public static ICollection<IdentityUserRole<Guid>> UserRoles = new List<IdentityUserRole<Guid>>
    {
        new IdentityUserRole<Guid>
        {
            UserId = Users.First().Id,
            RoleId = Roles.First().Id
        }
    };
    public static ICollection<Event> Events = new List<Event>
    {
        new Event
        {
            Name = "Name",
            Description = "Description",
            Plan = "Plan",
            Place = "Place",
            MeetupDate = DateTimeOffset.Now.AddHours(4)
        }
    };

    public static ICollection<EventRole> EventRoles = new List<EventRole>
    {
        new EventRole
        {
            Name = "Organizer",
            Role = RoleType.Creator
        },
        new EventRole
        {
            Name = "Speaker",
            Role = RoleType.Speaker
        },
        new EventRole
        {
            Name = "Member",
            Role = RoleType.Default
        }
    };

    public static ICollection<EventMember> EventMembers = new List<EventMember>
    {
        new EventMember
        {
            User = Users.FirstOrDefault(),
            Event = Events.FirstOrDefault(),
            EventRole = EventRoles.FirstOrDefault()
        }
    };
}