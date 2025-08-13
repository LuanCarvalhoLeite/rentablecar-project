using FluentAssertions;
using FluentValidation;
using RAC.Application.UseCases.Users;
using RAC.Communication.Requests;

namespace Valitador.Tests.Users;

public class PasswordValidatorTest
{
    [Theory]
    [InlineData("")]
    [InlineData("     ")]
    [InlineData("a")]
    [InlineData("aa")]
    [InlineData("aaa")]
    [InlineData("aaaa")]
    [InlineData("aaaaa")]
    [InlineData("aaaaaa")]
    [InlineData("aaaaaaa")]
    [InlineData("aaaaaaaa")]
    [InlineData("AAAAAAAA")]
    [InlineData("Aaaaaaaa")]
    [InlineData("Aaaaaaa1")]
    [InlineData(null)]
    public void Error_Password_Empty(string password)
    {
        //Arrange
        var validator = new PasswordValidator<RequestUser>();

        //Act
        var result = validator.IsValid(new ValidationContext<RequestUser>(new RequestUser()), password);

        //Assert
        result.Should().BeFalse();
    }
}
