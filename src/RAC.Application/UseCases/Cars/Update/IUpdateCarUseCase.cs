
using RAC.Communication.Requests;

namespace RAC.Application.UseCases.Cars.Update;

public interface IUpdateCarUseCase
{
    Task Execute(long id, RequestCar request);
}
