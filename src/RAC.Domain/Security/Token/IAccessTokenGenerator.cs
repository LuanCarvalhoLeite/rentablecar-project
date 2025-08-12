
using RAC.Domain.Entities;

namespace RAC.Domain.Security.Token;

public interface IAccessTokenGenerator
{
    string Generate(User user);
}
