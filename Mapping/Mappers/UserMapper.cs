using AutoMapper;
using Entities.Identity;
using Models.Core;

namespace Mapping.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserModel>();
    }
}