using DataAccessLayer.Abstractions.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.Repositories.DependencyInject
{
    public class ConfigureRepositories
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IEventRepository, EventRepository>();
        }
    }
}
