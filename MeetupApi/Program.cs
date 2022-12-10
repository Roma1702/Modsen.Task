using DataAccessLayer.Abstractions.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Repositories.DependencyInject;
using Domain.DependecyInject;
using Mapping.DependencyInject;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Validation.DependencyInject;

namespace MeetupApi;
public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Description = "Modsen Swagger API",
                Title = "Swagger with Identity Server 4",
                Version = "1.0.0"
            });
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Password = new OpenApiOAuthFlow
                    {
                        TokenUrl = new Uri(builder.Configuration.GetValue<string>("IdentityTokenUrl")),
                        Scopes = new Dictionary<string, string>
                        {
                            {"api", "api"}
                        }
                    }
                },
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "oauth2"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });

        builder.Services.ConfigureAuthService(builder.Configuration);

        builder.Services.ConfigureMappers();
        builder.Services.ConfigureRepositories();
        builder.Services.ConfigureServices();
        builder.Services.ConfigureValidators();

        builder.Services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("EntityConnection"),
                migration => migration.MigrationsAssembly(typeof(Program).Assembly.FullName));
            options.UseLazyLoadingProxies();
        });

        builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddTransient<IDbInitializer, DbInitializer>();

        var app = builder.Build();

        DbIntialize(app);

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger UI Demo");
                options.DocExpansion(DocExpansion.List);
                options.OAuthClientId("Api");
                options.OAuthClientSecret("client_secret");
            });
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
    private static void DbIntialize(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}