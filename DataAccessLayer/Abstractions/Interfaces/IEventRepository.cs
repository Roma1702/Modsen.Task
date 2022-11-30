using Models.Core;

namespace DataAccessLayer.Abstractions.Interfaces;

public interface IEventRepository
{
    public Task<List<EventModel>> GetChunkOfEventsWithSizeAsync(int number, int size);
    public Task<EventModel> GetEventByIdAsync(Guid id);
    public Task AddEventAsync(EventModel eventModel);
    public Task RemoveEventAsync(Guid id);
    public Task UpdateEventAsync(EventModel eventModel);
}