using Entities.Implementation;
using Models.Core;

namespace DataAccessLayer.Abstractions.Interfaces
{
    public interface IEventRoleRepository
    {
        public Task<EventRoleModel> GetEventRoleAsync(RoleType roleType);
        public Task<EventRoleModel?> GetEventRoleAsync(Guid id);
        public Task AddEventRoleAsync(EventRoleModel eventRole);
        public Task DeleteEventRoleAsync(Guid id);
        public Task UpdateEventRoleAsync(EventRoleModel eventRole);
    }
}
