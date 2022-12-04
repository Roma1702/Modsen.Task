namespace Entities.Implementation;

public enum RoleType {
    Default,
    Speaker,
    Creator
}
public class EventRole
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public virtual List<EventMember>? EventMembers { get; set; }
    public RoleType Role { get; set; }
}
