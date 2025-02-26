using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using Presentation.Common.Http;

namespace WebApplication3.Controller;
[ApiController]
public class ApiController : ControllerBase
{
    public IActionResult Problem(List<Error> errors)
    {
        var firstError = errors[0];
        HttpContext.Items[HttpContextItemKeys.Error] = errors;
        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        };

        return Problem(statusCode: statusCode, title: firstError.Description);
    }
}
