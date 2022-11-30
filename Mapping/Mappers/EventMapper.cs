using AutoMapper;
using Entities.Implementation;
using Models.Core;

namespace Mapping.Mappers;

public class EventMapper : Profile
{
    public EventMapper()
    {
        CreateMap<Event, EventModel>().ReverseMap();
    }
}