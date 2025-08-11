
using RAC.Communication.Requests;
using RAC.Communication.Responses;

namespace RAC.Application.UseCases.Cars.Register;

public interface IRegisterCarUseCase
{
    public Task<ResponseCarRegistered> Execute(RequestCar request);
}
