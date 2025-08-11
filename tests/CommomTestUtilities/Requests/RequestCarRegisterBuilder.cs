
using Bogus;
using RAC.Communication.Requests;

namespace CommomTestUtilities.Requests;

public static class RequestCarRegisterBuilder
{
    public static RequestCar Build()
    {
        return new Faker<RequestCar>()
            .RuleFor(r => r.Marca, faker => faker.Vehicle.Manufacturer())
            .RuleFor(r => r.Modelo, faker => faker.Vehicle.Model())
            .RuleFor(r => r.Preco, faker => faker.Random.Decimal(min: 1000, max: 100000000))
            .RuleFor(r => r.Ano, faker => faker.Date.Past(75).Year)
            .RuleFor(r => r.Categoria, faker => faker.PickRandom<RAC.Communication.Enum.Categoria>());
    }
}
