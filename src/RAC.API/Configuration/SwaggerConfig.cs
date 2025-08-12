using Microsoft.OpenApi.Models;

namespace RAC.API.Configuration;

public static class SwaggerConfig
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(config =>
        {
            config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorzation",
                Description = "JWT Authorization header using the Bearer scheme. Example: Bearer {token}",
                In = ParameterLocation.Header,
                Scheme = "Bearer",
                Type = SecuritySchemeType.ApiKey,
            });

            config.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>() {}
                }
            });

        });
    }
}
