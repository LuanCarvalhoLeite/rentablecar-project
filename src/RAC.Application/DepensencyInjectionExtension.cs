using Microsoft.Extensions.DependencyInjection;
using RAC.Application.AutoMapper;
using RAC.Application.UseCases.Cars.GetAll;
using RAC.Application.UseCases.Cars.GetById;
using RAC.Application.UseCases.Cars.Register;
using RAC.Application.UseCases.Cars.Remove;
using RAC.Application.UseCases.Cars.Update;
using RAC.Application.UseCases.Users.Register;

namespace RAC.Application;

public static class DepensencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        //AutoMapper
        services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapping>());

        //UseCases
        services.AddScoped<IRegisterCarUseCase, RegisterCarUseCase>();
        services.AddScoped<IGetAllCarsUseCase, GetAllCarsUseCase>();
        services.AddScoped<IGetCarByIdUseCase, GetCarByIdUseCase>();
        services.AddScoped<IRemoveCarUseCase, RemoveCarUseCase>();
        services.AddScoped<IUpdateCarUseCase, UpdateCarUseCase>();

        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
    }
}
