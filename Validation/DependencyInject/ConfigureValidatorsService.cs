using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Models.Core;
using Validation.Validators;

namespace Validation.DependencyInject
{
    public static class ConfigureValidatorsService
    {
        public static void ConfigureValidators(this IServiceCollection service)
        {
            service.AddScoped<IValidator<EventModel>,EventValidator>();
            service.AddScoped<IValidator<EventRoleModel>,EventRoleValidator>();
        }
    }
}
