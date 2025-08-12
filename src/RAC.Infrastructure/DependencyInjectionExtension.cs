using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RAC.Domain.Repositories;
using RAC.Domain.Repositories.Car;
using RAC.Domain.Repositories.User;
using RAC.Domain.Security.Cryptography;
using RAC.Domain.Security.Token;
using RAC.Infrastructure.Data;
using RAC.Infrastructure.Data.Repositories;
using RAC.Infrastructure.Security;

namespace RAC.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RentAbleCarDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IPasswordEncripter, Security.BCrypt>();

        AddToken(services, configuration);
        
    }

    public static void AddToken(this IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
    }
}