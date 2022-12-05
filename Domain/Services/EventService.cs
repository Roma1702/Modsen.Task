using DataAccessLayer.Abstractions.Interfaces;
using Domain.Abstractions.Interfaces;
using Entities.Implementation;
using Models.Core;

namespace Domain.Services
{
    public class EventService : IEventService
    {
        private readonly IEventMemberRepository _eventMemberRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IEventRoleRepository _eventRoleRepository;

        public EventService(IEventMemberRepository eventMemberRepository,
            IEventRepository eventRepository,
            IEventRoleRepository eventRoleRepository)
        {
            _eventMemberRepository = eventMemberRepository;
            _eventRepository = eventRepository;
            _eventRoleRepository = eventRoleRepository;
        }
        public async Task<List<EventModel>?> GetEventsAsync(int number, int size)
        {
            return await _eventRepository.GetChunkOfEventsWithSizeAsync(number, size);
        }

        public async Task<EventModel?> GetEventAsync(Guid id)
        {
            return await _eventRepository.GetEventByIdAsync(id);
        }

        public async Task CreateNewEventAsync(EventModel @event, Guid creatorId)
        {
            @event.Id = Guid.NewGuid();

            var eventRole = await _eventRoleRepository.GetEventRoleAsync(RoleType.Creator);

            await _eventRepository.AddEventAsync(@event);

            await _eventMemberRepository.AddEventMemberAsync(creatorId, @event.Id, eventRole?.Id ?? Guid.Empty);
        }
        public async Task DeleteEventAsync(Guid eventId, Guid creatorId)
        {
            var role = await GetRoleTypeOfInitiatorAsync(eventId, creatorId);

            if (role == RoleType.Creator)
            {
                await _eventRepository.RemoveEventAsync(eventId);

                await _eventMemberRepository.DeleteEventMemberAsyncByEventId(eventId);
            }
        }

        public async Task EditEventAsync(EventModel @event, Guid creatorId)
        {
            var role = await GetRoleTypeOfInitiatorAsync(@event.Id, creatorId);

            if (role == RoleType.Creator)
            {
                await _eventRepository.UpdateEventAsync(@event);
            }
        }

        public async Task InviteMemberAsync(Guid initiatorId, Guid eventId, Guid invitedId)
        {
            var role = await GetRoleTypeOfInitiatorAsync(eventId, initiatorId);

            var isAlreadyMember = await _eventMemberRepository.GetEventMemberAsync(initiatorId, eventId);

            if (isAlreadyMember is null)
            {
                if (role == RoleType.Creator)
                {
                    var roleTypeForMember = await _eventRoleRepository.GetEventRoleAsync(RoleType.Default);

                    await _eventMemberRepository.AddEventMemberAsync(invitedId, eventId, roleTypeForMember.Id);
                }
            }
        }

        public async Task PromoteEventMemberAsync(Guid initiatorId, Guid eventId, Guid memberId, Guid roleId)
        {
            var role = await GetRoleTypeOfInitiatorAsync(eventId, initiatorId);

            var isAlreadyMember = await _eventMemberRepository.GetEventMemberAsync(initiatorId, eventId);

            if (isAlreadyMember is not null)
            {
                if (role == RoleType.Creator)
                {
                    await _eventMemberRepository.EditEventMemberAsync(isAlreadyMember.Id, roleId);
                }
            }
        }

        private async Task<RoleType> GetRoleTypeOfInitiatorAsync(Guid eventId, Guid initiatorId)
        {
            var role = RoleType.Default;
            var initiatorMember = await _eventMemberRepository.GetEventMemberAsync(initiatorId, eventId);

            if (initiatorMember is not null)
            {
                var eventRoleModel = await _eventRoleRepository.GetEventRoleAsync(initiatorMember.RoleId);

                role = eventRoleModel?.Role ?? RoleType.Default;
            }

            return role;
        }
    }
}
