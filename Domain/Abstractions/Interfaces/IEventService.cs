using Models.Core;

namespace Domain.Abstractions.Interfaces
{
    public interface IEventService
    {
        public Task<List<EventModel>> GetChunkOfEventsWithSizeAsync(int number, int size);
        public Task CreateNewEventAsync(EventModel @event);
        public Task DeleteEventAsync(Guid id);
        public Task<EventModel> GetEventAsync(Guid id);
        public Task EditEventAsync(EventModel @event);
    }
}
