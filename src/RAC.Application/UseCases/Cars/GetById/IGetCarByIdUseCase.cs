
using RAC.Communication.Responses;

namespace RAC.Application.UseCases.Cars.GetById;

public interface IGetCarByIdUseCase
{
    public Task<CarInformation> Execute(long id);
}
