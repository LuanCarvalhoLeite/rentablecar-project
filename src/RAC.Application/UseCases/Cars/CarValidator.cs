
using FluentValidation;
using RAC.Communication.Requests;

namespace RAC.Application.UseCases.Cars;

public class CarValidator : AbstractValidator<RequestCar>
{
    public CarValidator()
    {
        RuleFor(car => car.Marca).NotEmpty().WithMessage("The brand cannot be null");
        RuleFor(car => car.Modelo).NotEmpty().WithMessage("The model cannot be null");
        RuleFor(car => car.Preco).GreaterThan(0).WithMessage("The price must be greater than zero");
        RuleFor(car => car.Ano).GreaterThan(1950).WithMessage("The year must be greater than 1950");
        RuleFor(car => car.Categoria).IsInEnum().WithMessage("The category must be a valid type");
    }
}
