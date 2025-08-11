
namespace RAC.Communication.Responses;

public class ResponseError
{
    public List<string> ErrorMessages { get; set; }

    public ResponseError(string errorMessage)
    {
        ErrorMessages = new List<string> { errorMessage };
    }
    public ResponseError(List<string> errorMessage)
    {
        ErrorMessages = errorMessage;
    }

}
