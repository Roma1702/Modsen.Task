using AutoMapper;
using DataAccessLayer.Abstractions.Interfaces;
using DataAccessLayer.Data;
using Entities.Implementation;
using Microsoft.EntityFrameworkCore;
using Models.Core;

namespace DataAccessLayer.Repositories
{
    public class EventMemberRepository : IEventMemberRepository
    {
        private readonly DbSet<EventMember>? _dbSet;
        private readonly ApplicationContext _applicationContext;
        private readonly IMapper _mapper;

        public EventMemberRepository(ApplicationContext context, IMapper mapper)
        {
            _applicationContext = context;
            _mapper = mapper;
            _dbSet = _applicationContext.Set<EventMember>();
        }

        public async Task AddEventMemberAsync(Guid userId, Guid eventId, Guid RoleId)
        {
            var isExistsEventAndMember = _dbSet!.AsNoTracking().Any(u => u.UserId == userId && u.EventId == eventId);

            if (!isExistsEventAndMember)
            {
                var eventMember = new EventMember
                {
                    RoleId = RoleId,
                    UserId = userId,
                    EventId = eventId
                };

                await _dbSet!.AddAsync(eventMember);

                await _applicationContext.SaveChangesAsync();
            }
        }

        public async Task DeleteEventMemberAsyncByEventId(Guid eventId)
        {
            var eventMembers = await _dbSet!.AsNoTracking().Where(x => x.EventId == eventId).ToListAsync();

            await DeleteEventMemberAsync(eventMembers);
        }

        public async Task DeleteEventMemberAsyncByUserId(Guid userId)
        {
            var eventMembers = await _dbSet!.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();

            await DeleteEventMemberAsync(eventMembers);
        }

        public async Task EditEventMemberAsync(Guid eventMemberId, Guid eventRoleId)
        {
            var eventMember = await _dbSet!.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == eventMemberId);

            if (eventMember is not null)
            {
                eventMember.RoleId = eventRoleId;

                _applicationContext.Entry(eventMember).State = EntityState.Modified;

                await _applicationContext.SaveChangesAsync();
            }
        }

        public async Task<EventMemberModel?> GetEventMemberAsync(Guid userId, Guid eventId)
        {
            var eventMember = await _dbSet!
                .AsNoTracking().
                FirstOrDefaultAsync(x => x.UserId == userId && x.EventId == eventId);

            var eventModel = _mapper.Map<EventMemberModel>(eventMember);

            return eventModel;
        }
        public async Task DeleteEventMemberAsync(List<EventMember> eventMembers)
        {
            foreach (var eventMember in eventMembers)
            {
                _applicationContext.Entry(eventMember).State = EntityState.Deleted;

                await _applicationContext.SaveChangesAsync();
            }
        }
    }
}
