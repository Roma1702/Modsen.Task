using DataAccessLayer.Data;
using Entities.Identity;
using IdentityServerApi.IdentityServerSettings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IdentityServerApi;
public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("_myAllowSpecificOrigins",
                              policy =>
                              {
                                  policy
                                  .WithOrigins("https://localhost:7168")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod();
                              });
        });

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

        app.InitializeDatabase();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("_myAllowSpecificOrigins");

        app.UseAuthorization();

        app.UseIdentityServer();

        app.MapControllers();

        app.Run();
    }
}
