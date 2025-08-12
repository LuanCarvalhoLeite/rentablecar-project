using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RAC.API.Configuration;

public static class JwtConfig
{
    public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {

        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddAuthentication(config =>
        {
            config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(config =>
        {
            config.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = new TimeSpan(0),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey!))
            };
        });

    }
}
