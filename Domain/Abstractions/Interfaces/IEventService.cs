using Models.Core;

namespace Domain.Abstractions.Interfaces
{
    public interface IEventService
    {
        public Task<List<EventModel>?> GetEventsAsync(int number, int size);
        public Task<EventModel?> GetEventAsync(Guid id);
        public Task CreateNewEventAsync(EventModel @event, Guid creatorId);
        public Task DeleteEventAsync(Guid eventId, Guid creatorId);
        public Task EditEventAsync(EventModel @event, Guid creatorId);
        public Task InviteMemberAsync(Guid initiatorId, Guid eventId, Guid invitedId);
        public Task PromoteEventMemberAsync(Guid initiatorId, Guid eventId, Guid memberId, Guid roleId);
    }
}
