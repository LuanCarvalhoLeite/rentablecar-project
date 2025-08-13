
using CommomTestUtilities.Requests;
using FluentAssertions;
using RAC.Application.UseCases.Users;

namespace Valitador.Tests.Users.Register;

public class RegisterUserValidationtest
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new UserValidator();
        var request = RequestRegisterUserBuilder.Build();

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("     ")]
    [InlineData(null)]
    public void Error_Name_Empty(string name)
    {
        //Arrange
        var validator = new UserValidator();
        var request = RequestRegisterUserBuilder.Build();
        request.Name = name;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("Name is required"));
    }

    [Theory]
    [InlineData("")]
    [InlineData("     ")]
    [InlineData(null)]
    public void Error_Email_Empty(string email)
    {
        //Arrange
        var validator = new UserValidator();
        var request = RequestRegisterUserBuilder.Build();
        request.Email = email;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("Email is required"));
    }

    [Fact]
    public void Error_Email_Invalid()
    {
        //Arrange
        var validator = new UserValidator();
        var request = RequestRegisterUserBuilder.Build();
        request.Email = "email.com@";

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("Invalid email format"));
    }
    [Fact]
    public void Error_Password_Empty()
    {
        //Arrange
        var validator = new UserValidator();
        var request = RequestRegisterUserBuilder.Build();
        request.Password = string.Empty;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("Your password must contain at least 8 characters " +
                "one upper letter, one lower letter, one number and a special character (for exemple,!,@,*,#,%)."));
    }


}
