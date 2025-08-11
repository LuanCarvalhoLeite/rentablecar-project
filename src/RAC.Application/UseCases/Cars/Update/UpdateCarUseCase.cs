using AutoMapper;
using RAC.Communication.Requests;
using RAC.Domain.Repositories;
using RAC.Domain.Repositories.Car;
using RAC.Exception.ExceptionBase;

namespace RAC.Application.UseCases.Cars.Update;

public class UpdateCarUseCase : IUpdateCarUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICarRepository _carRepository;

    public UpdateCarUseCase(IUnitOfWork unitOfWork, IMapper mapper, ICarRepository carRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _carRepository = carRepository;
    }

    public async Task Execute(long id, RequestCar request)
    {
        Validate(request);

        var car = await _carRepository.GetById(id);

        if(car is null)
        {
            throw new NotFoundException("The car was not found");
        }

        _mapper.Map(request, car);

        _carRepository.UpdateCar(car);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestCar request)
    {
        var validator = new CarValidator();

        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
