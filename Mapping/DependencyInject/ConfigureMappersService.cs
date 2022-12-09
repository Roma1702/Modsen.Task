using AutoMapper;
using Mapping.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Mapping.DependencyInject;

public static class ConfigureMappersService
{
    public static void ConfigureMappers(this IServiceCollection services)
    {
        var mapperConfiguration = new MapperConfiguration(options =>
        {
            options.AddProfile(new EventMapper());
            options.AddProfile(new EventRoleMapper());
            options.AddProfile(new EventMemberMapper());
        });

        var mapper = mapperConfiguration.CreateMapper();
        services.AddSingleton(mapper);
    }
}