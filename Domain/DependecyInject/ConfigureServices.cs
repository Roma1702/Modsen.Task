using Domain.Abstractions.Interfaces;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.DependecyInject
{
    public class ConfigureServices
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IEventService, EventService>();
        }
    }
}
