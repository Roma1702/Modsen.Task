using Domain.Abstractions.Interfaces;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Core;

namespace MeetupApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [HttpGet]
        public async Task<List<EventModel>> GetChunkOfEventsWithSizeAsync(int number, int size)
        {
            return await _eventService.GetChunkOfEventsWithSizeAsync(number, size);
        }
        [HttpGet("id")]
        public async Task<EventModel> GetSingleEventAsync(Guid id)
        {
            return await _eventService.GetEventAsync(id);
        }
        [HttpPost]
        public async Task CreateNewEventAsync(EventModel @event)
        {
            await _eventService.CreateNewEventAsync(@event);
        }
        [HttpPut]
        public async Task EditEventAsync(EventModel @event)
        {
            await _eventService.EditEventAsync(@event);
        }
        [HttpDelete("id")]
        public async Task RemoveEventAsync(Guid id)
        {
            await _eventService.DeleteEventAsync(id);
        }
    }
}
