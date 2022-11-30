using DataAccessLayer.Data;
using Entities.Identity;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServerApi.IdentityServerSettings;

namespace IdentityServerApi;
public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var migrationAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

        builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("EntityConnection"),
            migration => migration.MigrationsAssembly(migrationAssembly)));

        builder.Services.AddIdentity<User, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
            .AddUserManager<UserManager<User>>()
            .AddDefaultTokenProviders();

        builder.Services.AddIdentityServer(options =>
        {
            options.UserInteraction.LoginUrl = null;
        })
        .AddConfigurationStore(options =>
        {
            options.ConfigureDbContext = context =>
            context.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"),
             migration => migration.MigrationsAssembly(migrationAssembly));
        })
        .AddOperationalStore(options =>
        {
            options.ConfigureDbContext = context =>
            context.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"),
             migration => migration.MigrationsAssembly(migrationAssembly));
        })
        .AddDeveloperSigningCredential()
        .AddAspNetIdentity<User>();

        var app = builder.Build();

        IdentityServerDbInitializer.InitializeDatabase(app);

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseIdentityServer();

        app.MapControllers();

        app.Run();
    }
}
