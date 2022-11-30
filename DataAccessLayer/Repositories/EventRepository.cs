using AutoMapper;
using DataAccessLayer.Abstractions.Interfaces;
using DataAccessLayer.Data;
using Entities.Implementation;
using Microsoft.EntityFrameworkCore;
using Models.Core;

namespace DataAccessLayer.Repositories;

public class EventRepository : IEventRepository
{
    private readonly ApplicationContext _applicationContext;
    private readonly DbSet<Event> _dbSet;
    private readonly IMapper _mapper;
    public EventRepository(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
        _dbSet = applicationContext.Set<Event>();
    }

    public async Task AddEventAsync(EventModel eventModel)
    {
        var @event = _mapper.Map<Event>(eventModel);
        await _dbSet.AddAsync(@event);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task<List<EventModel>> GetChunkOfEventsWithSizeAsync(int number, int size)
    {
        var events = await _dbSet.AsNoTracking().Skip(number * size).Take(size).ToListAsync();
        var eventModels = _mapper.Map<List<EventModel>>(events);
        return eventModels;
    }

    public async Task<EventModel> GetEventByIdAsync(Guid id)
    {
        var @event = await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        var eventModel = _mapper.Map<EventModel>(@event);
        return eventModel;
    }

    public async Task RemoveEventAsync(Guid id)
    {
        var @event = await _dbSet.FindAsync(id);

        if (@event is not null)
        {
            _dbSet.Remove(@event);
            await _applicationContext.SaveChangesAsync();
        }
    }

    public async Task UpdateEventAsync(EventModel eventModel)
    {
        var @event = _mapper.Map<Event>(eventModel);
        _dbSet.Attach(@event);
        _applicationContext.Entry(@event).State = EntityState.Modified;
        await _applicationContext.SaveChangesAsync();
    }
}