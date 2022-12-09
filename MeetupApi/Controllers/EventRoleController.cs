using DataAccessLayer.Abstractions.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Core;

namespace MeetupApi.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventRoleController : ControllerBase
    {
        private readonly IEventRoleRepository _eventRoleRepository;

        public EventRoleController(IEventRoleRepository eventRoleRepository)
        {
            _eventRoleRepository = eventRoleRepository;
        }
        [HttpPost("add")]
        public async Task AddEventRoleAsync(EventRoleModel eventRoleModel)
        {
            await _eventRoleRepository.AddEventRoleAsync(eventRoleModel);
        }
        [HttpPut("update")]
        public async Task EditEventRoleAsync(EventRoleModel eventRoleModel)
        {
            await _eventRoleRepository.UpdateEventRoleAsync(eventRoleModel);
        }
        [HttpDelete("delete")]
        public async Task DeleteEventRoleRepository(Guid roleId)
        {
            await _eventRoleRepository.DeleteEventRoleAsync(roleId);
        }
    }
}
