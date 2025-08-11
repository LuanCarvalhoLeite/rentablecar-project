
namespace RAC.Exception.ExceptionBase;

public abstract class RentAbleCarException : SystemException
{
    protected RentAbleCarException(string message) : base(message)
    {
        
    }
    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
