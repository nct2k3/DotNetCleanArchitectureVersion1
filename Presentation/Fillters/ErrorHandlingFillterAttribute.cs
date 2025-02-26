using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication3.Fillters;

public class ErrorHandlingFillterAttribute: ExceptionFilterAttribute
{
    // handling error and result error detail
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        var problemDetail = new ProblemDetails
        {
            Type = "https://httpstatuses.com/500",
            Title = exception.Message,
            Status = (int)HttpStatusCode.InternalServerError,

        };
        context.Result = new ObjectResult(problemDetail)
        {
            StatusCode = 500
        };
        context.ExceptionHandled = true;
    }
    
}