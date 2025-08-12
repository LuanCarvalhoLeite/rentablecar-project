
using RAC.Communication.Requests;
using RAC.Communication.Responses;
using RAC.Domain.Repositories.User;
using RAC.Domain.Security.Cryptography;
using RAC.Domain.Security.Token;
using RAC.Exception.ExceptionBase;

namespace RAC.Application.UseCases.Login;

public class LoginUseCase : ILoginUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public LoginUseCase(IUserRepository userRepository, 
        IPasswordEncripter passwordEncripter, 
        IAccessTokenGenerator accessTokenGenerator)
    {
        _userRepository = userRepository;
        _passwordEncripter = passwordEncripter;
        _accessTokenGenerator = accessTokenGenerator;
    }

    public async Task<ResponseUser> Execute(RequestLogin request)
    {
        var user = await _userRepository.GetUserByEmail(request.Email);
        
        if(user is null)
        {
            throw new InvalidLoginException();
        }

        var passwordMatch = _passwordEncripter.Verify(request.Password, user.Password);

        if (passwordMatch == false)
        {
            throw new InvalidLoginException();
        }

        return new ResponseUser
        {
            Name = user.Name,
            Token = _accessTokenGenerator.Generate(user)
        };
    }
}
