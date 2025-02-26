using Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApplication3.Errors;

namespace WebApplication3.Controller
{
  /*  [ApiController]
    [Route("/error")]
    public class ErrorController : ControllerBase
    {
        private readonly ProblemDetailsFactory _problemDetailsFactory;

        public ErrorController(ProblemDetailsFactory problemDetailsFactory)
        {
            _problemDetailsFactory = problemDetailsFactory;
        }
        [HttpGet, HttpPost, HttpPut, HttpDelete, HttpPatch]
        public IActionResult HandleError()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, title) = exception switch
            {
                IServiceException serviceException =>
                    ((int)serviceException.StatusCode,serviceException.Title),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
            };
            
            var problemDetails = _problemDetailsFactory.CreateProblemDetails(
                HttpContext,
                statusCode,
                title
            );

            return new ObjectResult(problemDetails)
            {
                StatusCode = statusCode
            };
        }
    }*/
  
  [Route("/error")]
  public class ErrorsController : ControllerBase
  {
      public IActionResult Error()
      {
          Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

          var (statusCode, message) = exception switch
          {
              IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.Title),
              _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
          };

          return Problem(statusCode: statusCode, title: message);
      }
  }



}