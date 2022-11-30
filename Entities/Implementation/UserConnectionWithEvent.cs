using Entities.Identity;

namespace Entities.Implementation
{
    public class UserConnectionWithEvent
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public virtual Event? Event { get; set; }
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
