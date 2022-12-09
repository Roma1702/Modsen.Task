using AutoMapper;
using Entities.Implementation;
using Models.Core;

namespace Mapping.Mappers
{
    public class EventRoleMapper : Profile
    {
        public EventRoleMapper()
        {
            CreateMap<EventRole, EventRoleModel>().ReverseMap();
        }
    }
}
