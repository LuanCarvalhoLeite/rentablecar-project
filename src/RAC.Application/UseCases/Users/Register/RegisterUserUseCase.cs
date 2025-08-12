
using AutoMapper;
using RAC.Communication.Requests;
using RAC.Communication.Responses;
using RAC.Domain.Security.Cryptography;
using RAC.Exception.ExceptionBase;

namespace RAC.Application.UseCases.Users.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IPasswordEncripter _passwordEncripter;

    public RegisterUserUseCase(IMapper mapper, IPasswordEncripter passwordEncripter)
    {
        _mapper = mapper;
        _passwordEncripter = passwordEncripter;
    }

    public async Task<ResponseUser> Execute(RequestUser request)
    {
        Validate(request);

        var user = _mapper.Map<Domain.Entities.User>(request);
        user.Password = _passwordEncripter.Encrypt(request.Password);

        return new ResponseUser
        {
            Name = user.Name,

        };
    }

    private void Validate(RequestUser request)
    {
        var result = new UserValidator().Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
