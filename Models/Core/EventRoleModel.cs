using Entities.Implementation;

namespace Models.Core
{
    public class EventRoleModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public RoleType Role { get; set; }
    }
}
