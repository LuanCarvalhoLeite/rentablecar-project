
using RAC.Communication.Requests;
using RAC.Communication.Responses;

namespace RAC.Application.UseCases.Cars.GetAll;

public interface IGetAllCarsUseCase
{
    public Task<ResponseCarsList> Execute();
}
