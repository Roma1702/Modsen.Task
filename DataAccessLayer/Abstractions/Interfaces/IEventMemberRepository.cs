using Models.Core;

namespace DataAccessLayer.Abstractions.Interfaces
{
    public interface IEventMemberRepository
    {
        public Task AddEventMemberAsync(Guid userId, Guid eventId, Guid RoleId);
        public Task EditEventMemberAsync(Guid eventMemberId, Guid eventRoleId);
        public Task DeleteEventMemberAsyncByUserId(Guid userId);
        public Task DeleteEventMemberAsyncByEventId(Guid eventId);
        public Task<EventMemberModel?> GetEventMemberAsync(Guid userId, Guid eventId);
    }
}
