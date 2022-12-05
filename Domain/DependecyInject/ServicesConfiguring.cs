using Domain.Abstractions.Interfaces;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.DependecyInject
{
    public static class ServicesConfiguring
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IIdentityService, IdentityService>();
        }
    }
}
