namespace Models.Core
{
    public class EventMemberModel
    {
        public Guid Id { get; set; }
        public Guid UserId{ get; set; }
        public Guid EventId{ get; set; }
        public Guid RoleId{ get; set; }
    }
}
