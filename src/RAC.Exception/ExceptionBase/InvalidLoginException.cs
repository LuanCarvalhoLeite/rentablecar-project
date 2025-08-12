

using System.Net;

namespace RAC.Exception.ExceptionBase;

public class InvalidLoginException : RentAbleCarException
{
    public InvalidLoginException() : base("Email or Password Invalid")
    {
    }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
