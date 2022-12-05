using AutoMapper;
using DataAccessLayer.Abstractions.Interfaces;
using DataAccessLayer.Data;
using Entities.Implementation;
using Microsoft.EntityFrameworkCore;
using Models.Core;

namespace DataAccessLayer.Repositories
{
    public class EventRoleRepository : IEventRoleRepository
    {
        private readonly ApplicationContext _applicatioinContext;
        private readonly IMapper _mapper;
        private readonly DbSet<EventRole>? _dbSet;

        public EventRoleRepository(ApplicationContext applicationContext, IMapper mapper)
        {
            _applicatioinContext = applicationContext;
            _mapper = mapper;
            _dbSet = applicationContext.Set<EventRole>();
        }
        public async Task AddEventRoleAsync(EventRoleModel eventRoleModel)
        {
            var eventRole = _mapper.Map<EventRole>(eventRoleModel);

            await _dbSet!.AddAsync(eventRole);

            await _applicatioinContext.SaveChangesAsync();
        }

        public async Task DeleteEventRoleAsync(Guid id)
        {
            var eventRole = await _dbSet!.FindAsync(id);

            if (eventRole is not null)
            {
                _dbSet.Remove(eventRole);

                await _applicatioinContext.SaveChangesAsync();
            }
        }

        public async Task<EventRoleModel?> GetEventRoleAsync(Guid id)
        {
            var eventRole = await _dbSet!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            var eventRoleModel = _mapper.Map<EventRoleModel>(eventRole);

            return eventRoleModel;
        }

        public async Task<EventRoleModel> GetEventRoleAsync(RoleType roleType)
        {
            var eventRole = await _dbSet!.AsNoTracking().FirstOrDefaultAsync(x => x.Role == roleType);

            var eventRoleModel = _mapper.Map<EventRoleModel>(eventRole);

            return eventRoleModel;
        }

        public async Task UpdateEventRoleAsync(EventRoleModel eventRoleModel)
        {
            var eventRole = _mapper.Map<EventRole>(eventRoleModel);

            _dbSet!.Attach(eventRole);
            _applicatioinContext.Entry(eventRole).State = EntityState.Modified;

            await _applicatioinContext.SaveChangesAsync();
        }
    }
}
