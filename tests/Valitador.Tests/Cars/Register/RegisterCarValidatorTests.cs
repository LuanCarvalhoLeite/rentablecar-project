using CommomTestUtilities.Requests;
using FluentAssertions;
using RAC.Application.UseCases.Cars;

namespace Valitador.Tests.Cars.Register;

public class RegisterCarValidatorTests
{

    [Fact]
    public void Sucess()
    {
        //Arrange
        var validator = new CarValidator();
        var request = RequestCarRegisterBuilder.Build();

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Error_Marca_Empty()
    {
        //Arrange
        var validator = new CarValidator();
        var request = RequestCarRegisterBuilder.Build();
        request.Marca = string.Empty;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("The brand cannot be null"));
    }

    [Fact]
    public void Error_Modelo_Empty()
    {
        //Arrange
        var validator = new CarValidator();
        var request = RequestCarRegisterBuilder.Build();
        request.Modelo = string.Empty;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("The model cannot be null"));
    }

    [Fact]
    public void Error_Preco_Empty()
    {
        //Arrange
        var validator = new CarValidator();
        var request = RequestCarRegisterBuilder.Build();
        request.Preco = 0;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("The price must be greater than zero"));
    }

    [Fact]
    public void Error_Ano_Empty()
    {
        //Arrange
        var validator = new CarValidator();
        var request = RequestCarRegisterBuilder.Build();
        request.Ano = 1949;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("The year must be greater than 1950"));
    }

    [Fact]
    public void Error_Categoria_Empty()
    {
        //Arrange
        var validator = new CarValidator();
        var request = RequestCarRegisterBuilder.Build();
        request.Categoria = (RAC.Communication.Enum.Categoria)999;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("The category must be a valid type"));
    }

}
