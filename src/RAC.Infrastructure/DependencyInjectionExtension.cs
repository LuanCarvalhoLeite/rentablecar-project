using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RAC.Domain.Repositories;
using RAC.Domain.Repositories.Car;
using RAC.Domain.Security.Cryptography;
using RAC.Infrastructure.Data;
using RAC.Infrastructure.Data.Repositories;

namespace RAC.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RentAbleCarDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ICarRepository, CarRepository>();

        services.AddScoped<IPasswordEncripter, Security.BCrypt>();
    }
}
