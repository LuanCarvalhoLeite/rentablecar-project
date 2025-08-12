
using RAC.Communication.Requests;
using RAC.Communication.Responses;

namespace RAC.Application.UseCases.Login;

public interface ILoginUseCase
{
    Task<ResponseUser> Execute(RequestLogin request);
}
