using Application.Authentication.Quries.Login;
using Application.Common.Errors;
using Application.Common.Interfaces.Authentication;
using Microsoft.AspNetCore.Mvc;
using Application.Service.Authentication;
using Contracts;
using MapsterMapper;
using MediatR;
namespace WebApplication3.Controller;
using ErrorOr;

[ApiController]
[Route("auth")]
public class AuthenticationController : ApiController
{
    
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    

    public AuthenticationController( ISender mediator, IMapper mapper)
    {
       _mediator = mediator;
       _mapper = mapper;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Domanin.Commom.Errors.Errors.Authentication.InvalidCrendentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description
            );
        }

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
    }


    /*[HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {

        var command = _mapper.Map<RegisterCommand>(registerRequest);
        var authResult = await _mediator.Send(command);
            
            
        if (authResult == null)
        {
            return Conflict(new ProblemDetails
            {
                Title = "Email already exists.",
                Status = StatusCodes.Status409Conflict,
                Detail = "The email address is already in use."
            });
        }
        var response =_mapper.Map<AuthenticationResult>(authResult);
        Console.WriteLine(response);

        return Ok(response);
    }*/

   /* [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        var query= _mapper.Map<LoginQuery>(loginRequest);
        var authResult = await _mediator.Send(query);

        if (authResult == null)
        {
            return Unauthorized(new ProblemDetails
            {
                Title = "Invalid login credentials.",
                Status = StatusCodes.Status401Unauthorized,
                Detail = "The email or password provided is incorrect."
            });
        }
        
        var response = _mapper.Map<AuthenticationResult>(authResult);

        return Ok(response);
    }*/
}
