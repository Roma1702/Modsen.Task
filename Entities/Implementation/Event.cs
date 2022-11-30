using Entities.Identity;

namespace Entities.Implementation;

public class Event
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Plan { get; set; }
    public virtual List<UserConnectionWithEvent>? ConnectionWithUsers { get; set; }
    public DateTimeOffset MeetupDate { get; set; }
    public string? Place { get; set; }
}
