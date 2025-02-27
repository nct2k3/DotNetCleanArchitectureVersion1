using Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApplication3.Errors;

namespace WebApplication3.Controller
{
    
  [Route("/error")]
  public class ErrorsController : ControllerBase
  {
      [HttpGet, HttpPost, HttpPut, HttpDelete, HttpPatch]
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