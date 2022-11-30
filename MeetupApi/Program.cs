using DataAccessLayer.Abstractions.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Repositories.DependencyInject;
using Domain.DependecyInject;
using Mapping.DependencyInject;
using Microsoft.EntityFrameworkCore;

namespace MeetupApi;
public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.ConfigureAuthService(builder.Configuration);

        ConfigureMappers.Configure(builder.Services);
        ConfigureServices.Configure(builder.Services);
        ConfigureRepositories.Configure(builder.Services);

        builder.Services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("EntityConnection"),
                migration => migration.MigrationsAssembly(typeof(Program).Assembly.FullName));
            options.UseLazyLoadingProxies();
        });

        builder.Services.AddTransient<IDbInitializer, DbInitializer>();

        var app = builder.Build();

        DbIntialize(app);

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
    private static void DbIntialize(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            dbInitializer.Initialize();
        }
    }
}