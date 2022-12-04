using Entities.Identity;

namespace Entities.Implementation
{
    public class EventMember
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public virtual Event? Event { get; set; }
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }
        public Guid RoleId { get; set; }
        public virtual EventRole? EventRole { get; set; }
    }
}
