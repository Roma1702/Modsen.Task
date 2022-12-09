using Domain.Abstractions.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Core;

namespace MeetupApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IIdentityService _identityService;

        public EventController(IEventService eventService, IIdentityService identityService)
        {
            _eventService = eventService;
            _identityService = identityService;
        }
        [HttpGet("id")]
        public async Task<EventModel?> GetEventAsync(Guid eventId)
        {
            return await _eventService.GetEventAsync(eventId);
        }
        [HttpGet("chunk")]
        public async Task<List<EventModel>?> GetChunkOfAllEventsAsync(int number, int size)
        {
            return await _eventService.GetEventsAsync(number, size);
        }
        [HttpDelete("delete")]
        [Authorize]
        public async Task DeleteEventAsync(Guid id)
        {
            var userId = _identityService.GetUserIdentity();

            await _eventService.DeleteEventAsync(id, Guid.Parse(userId));
        }
        [HttpPost("invite")]
        [Authorize]
        public async Task InviteUserAsync(Guid eventId, Guid invitedId)
        {
            var userId = _identityService.GetUserIdentity();

            await _eventService.InviteMemberAsync(Guid.Parse(userId), eventId, invitedId);
        }
        [HttpPost("create")]
        [Authorize]
        public async Task CreateEventAsync(EventModel eventModel)
        {
            var userId = _identityService.GetUserIdentity();

            await _eventService.CreateNewEventAsync(eventModel, Guid.Parse(userId));
        }
        [HttpPut("updateEvent")]
        [Authorize]
        public async Task UpdateEventAsync(EventModel eventModel)
        {
            var userId = _identityService.GetUserIdentity();

            await _eventService.EditEventAsync(eventModel, Guid.Parse(userId));
        }
        [HttpPut("promote")]
        [Authorize]
        public async Task PromoteUserAsync(Guid eventid, Guid invitedId, Guid roleId)
        {
            var userId = _identityService.GetUserIdentity();

            await _eventService.PromoteEventMemberAsync(Guid.Parse(userId), eventid, invitedId, roleId);
        }
    }
}
