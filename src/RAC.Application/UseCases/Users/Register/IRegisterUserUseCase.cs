
using RAC.Communication.Requests;
using RAC.Communication.Responses;

namespace RAC.Application.UseCases.Users.Register;

public interface IRegisterUserUseCase
{
    Task<ResponseUser> Execute(RequestUser request);
}
