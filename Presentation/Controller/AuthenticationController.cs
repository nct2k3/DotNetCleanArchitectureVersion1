﻿using Application.Authentication.Quries.Login;
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
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResult>(authResult)),
            errors => Problem(errors)
        );
    }

    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query =_mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Domanin.Commom.Errors.Errors.Authentication.InvalidCrendentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description
            );
        }

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResult>(authResult)),
            errors => Problem(errors)
        );
    }
    
}
