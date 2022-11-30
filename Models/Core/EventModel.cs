namespace Models.Core;

public class EventModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Plan { get; set; }
    public Guid SpeakerId { get; set; }
    public Guid OrganizerId { get; set; }
    public DateTimeOffset? MeetupDate { get; set; }
    public string? Place { get; set; }
}
