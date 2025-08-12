using RAC.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace RAC.Infrastructure.Security;

public class BCrypt : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        string passwordHash = BC.HashPassword(password);
        return passwordHash;
    }
}
