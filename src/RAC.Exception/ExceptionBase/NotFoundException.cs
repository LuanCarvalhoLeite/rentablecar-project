
using System.Net;

namespace RAC.Exception.ExceptionBase;

public class NotFoundException : RentAbleCarException
{
    public NotFoundException(string message) : base(message)
    {
        
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return new List<string> { Message };
    }
}
