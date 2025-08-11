
using AutoMapper;
using RAC.Communication.Requests;
using RAC.Communication.Responses;
using RAC.Domain.Repositories;
using RAC.Domain.Repositories.Car;

namespace RAC.Application.UseCases.Cars.GetAll;

public class GetAllCarsUseCase : IGetAllCarsUseCase
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetAllCarsUseCase(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<ResponseCarsList> Execute()
    {
        var result = await _carRepository.GetAllCars();

        return new ResponseCarsList
        {
            CarList = _mapper.Map<List<CarInformation>>(result)
        };

    }

}
