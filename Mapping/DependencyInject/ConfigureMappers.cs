using AutoMapper;
using Mapping.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Mapping.DependencyInject;

public static class ConfigureMappers
{
    public static void Configure(IServiceCollection services)
    {
        var mapperConfiguration = new MapperConfiguration(options =>
        {
            options.AddProfile(new EventMapper());
            options.AddProfile(new UserMapper());
        });

        var mapper = mapperConfiguration.CreateMapper();
        services.AddSingleton(mapper);
    }
}