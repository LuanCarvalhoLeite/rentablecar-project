
using AutoMapper;
using RAC.Communication.Requests;
using RAC.Communication.Responses;
using RAC.Domain.Repositories;
using RAC.Domain.Repositories.Car;
using RAC.Exception.ExceptionBase;

namespace RAC.Application.UseCases.Cars.Register;

public class RegisterCarUseCase : IRegisterCarUseCase
{
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterCarUseCase(ICarRepository carRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseCarRegistered> Execute(RequestCar request)
    {
        Validate(request);

        var entity = _mapper.Map<RAC.Domain.Entities.Car>(request);
        await _carRepository.AddCar(entity);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponseCarRegistered>(entity);
    }

    public void Validate(RequestCar request)
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
