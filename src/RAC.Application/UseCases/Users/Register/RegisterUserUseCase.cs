using AutoMapper;
using FluentValidation.Results;
using RAC.Communication.Requests;
using RAC.Communication.Responses;
using RAC.Domain.Repositories;
using RAC.Domain.Repositories.User;
using RAC.Domain.Security.Cryptography;
using RAC.Exception.ExceptionBase;

namespace RAC.Application.UseCases.Users.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserUseCase(IMapper mapper,
        IPasswordEncripter passwordEncripter, 
        IUserRepository userRepository, 
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _passwordEncripter = passwordEncripter;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseUser> Execute(RequestUser request)
    {
        await Validate(request);

        var user = _mapper.Map<Domain.Entities.User>(request);
        user.Password = _passwordEncripter.Encrypt(request.Password);
        user.UserIdentifier = Guid.NewGuid();

        await _userRepository.AddUser(user);
        await _unitOfWork.Commit();

        return new ResponseUser
        {
            Name = user.Name,

        };
    }

    private async Task Validate(RequestUser request)
    {
        var result = new UserValidator().Validate(request);

        var emailExist = await _userRepository.ExistActiveUserEmail(request.Email);

        if (emailExist)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, "Email already exists"));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
