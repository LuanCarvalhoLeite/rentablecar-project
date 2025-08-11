
using AutoMapper;
using RAC.Communication.Responses;
using RAC.Domain.Repositories.Car;
using RAC.Exception.ExceptionBase;

namespace RAC.Application.UseCases.Cars.GetById;

public class GetCarByIdUseCase : IGetCarByIdUseCase
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetCarByIdUseCase(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<CarInformation> Execute(long id)
    {
        var result = await _carRepository.GetCarById(id);

        if (result == null)
        {
            throw new NotFoundException("The car was not found.");
        }

        return _mapper.Map<CarInformation>(result);

    }
}
