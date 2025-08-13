using Bogus;
using RAC.Communication.Requests;
using System.Net.NetworkInformation;

namespace CommomTestUtilities.Requests;

public class RequestRegisterUserBuilder
{
    public static RequestUser Build()
    {
        return new Faker<RequestUser>()
            .RuleFor(user => user.Name, faker => faker.Person.FirstName)
            .RuleFor(user => user.Email, (faker, user) => faker.Internet.Email(user.Name))
            .RuleFor(user => user.Password, faker => faker.Internet.Password(prefix: "@Aa1"));
    }
}
