using Application.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using Application.Service.Authentication;
using Contracts;

namespace WebApplication3.Controller;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest registerRequest)
    {
        var authResult = _authenticationService.Register(
            registerRequest.FirstName,
            registerRequest.LastName,
            registerRequest.Email,
            registerRequest.Password
        );

        if (authResult == null)
        {
            // Trả về lỗi nếu email đã tồn tại
            return Conflict(new ProblemDetails
            {
                Title = "Email already exists.",
                Status = StatusCodes.Status409Conflict,
                Detail = "The email address is already in use."
            });
        }

        // Nếu thành công, trả về thông tin đăng ký
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        var authResult = _authenticationService.Login(
            loginRequest.Email,
            loginRequest.Password
        );

        if (authResult == null)
        {
            // Trả về lỗi nếu thông tin đăng nhập không hợp lệ
            return Unauthorized(new ProblemDetails
            {
                Title = "Invalid login credentials.",
                Status = StatusCodes.Status401Unauthorized,
                Detail = "The email or password provided is incorrect."
            });
        }

        // Nếu đăng nhập thành công
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );

        return Ok(response);
    }
}
