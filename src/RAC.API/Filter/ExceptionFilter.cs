using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RAC.Communication.Responses;
using RAC.Exception.ExceptionBase;

namespace RAC.API.Filter;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is RentAbleCarException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    public void HandleProjectException(ExceptionContext context)
    {
        var rentAbleCarException = (RentAbleCarException)context.Exception;
        var errorResponse = new ResponseError(rentAbleCarException.GetErrors());


        context.HttpContext.Response.StatusCode = rentAbleCarException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
        
    }

    public void ThrowUnknowError(ExceptionContext context)
    {
        var errorResponse = new ResponseError("Unknow Error");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
