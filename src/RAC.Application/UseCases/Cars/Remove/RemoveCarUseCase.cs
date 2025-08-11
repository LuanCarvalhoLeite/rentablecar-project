

using RAC.Domain.Repositories;
using RAC.Domain.Repositories.Car;
using RAC.Exception.ExceptionBase;

namespace RAC.Application.UseCases.Cars.Remove;

public class RemoveCarUseCase : IRemoveCarUseCase
{
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveCarUseCase(ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
    }
     
    public async Task Execute(long id)
    {
        var result = await _carRepository.RemoveCar(id);

        if (result is false)
        {
            throw new NotFoundException("The car was not found");
        }
        await _unitOfWork.Commit();
    }
}
