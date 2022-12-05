using DataAccessLayer.Abstractions.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.Repositories.DependencyInject
{
    public static class ConfigureRepositoriesService
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IEventMemberRepository, EventMemberRepository>();
            services.AddTransient<IEventRoleRepository, EventRoleRepository>();
        }
    }
}
