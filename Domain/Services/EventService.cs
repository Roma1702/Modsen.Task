using DataAccessLayer.Abstractions.Interfaces;
using Domain.Abstractions.Interfaces;
using Models.Core;

namespace Domain.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task CreateNewEventAsync(EventModel @event)
        {
            await _eventRepository.AddEventAsync(@event);
        }

        public async Task DeleteEventAsync(Guid id)
        {
            await _eventRepository.RemoveEventAsync(id);
        }

        public async Task EditEventAsync(EventModel @event)
        {
            await _eventRepository.UpdateEventAsync(@event);
        }

        public async Task<List<EventModel>> GetChunkOfEventsWithSizeAsync(int number, int size)
        {
            return await _eventRepository.GetChunkOfEventsWithSizeAsync(number, size);
        }

        public async Task<EventModel> GetEventAsync(Guid id)
        {
            return await _eventRepository.GetEventByIdAsync(id);
        }
    }
}
