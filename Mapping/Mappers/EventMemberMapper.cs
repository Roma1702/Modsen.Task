using AutoMapper;
using Entities.Implementation;
using Models.Core;

namespace Mapping.Mappers
{
    public class EventMemberMapper : Profile
    {
        public EventMemberMapper()
        {
            CreateMap<EventMember, EventMemberModel>().ReverseMap();
        }
    }
}
