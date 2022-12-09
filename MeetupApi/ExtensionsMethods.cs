using Entities.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace MeetupApi;

public static class ExtensionsMethods
{
    public static void ConfigureAuthService(this IServiceCollection services, IConfiguration configuration)
    {
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

        var identityUrl = configuration.GetValue<string>("IdentityUrl");

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = "Bearer";
            options.DefaultAuthenticateScheme = "Bearer";
            options.DefaultChallengeScheme = "Bearer";
        }).AddJwtBearer(options =>
        {
            options.Authority = identityUrl;
            options.RequireHttpsMetadata = false;
            options.Audience = "api";
        });

        services.AddAuthorization();
    }
}