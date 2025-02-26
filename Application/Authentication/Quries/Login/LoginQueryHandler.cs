using Application.Service.Authentication;

namespace Application.Authentication.Quries.Login;

using Application.Common.Errors;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domanin.Entities;
using MediatR;
using ErrorOr;


public class LoginQueryHandler:IRequestHandler<LoginQuery,ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }


    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(request.Email) is not User user)
        {
            throw new Exception("User with email address does not exist");
        }

        if (user.Password != request.Password)
        {
            throw new Exception("Passwords do not match");
        }
        var Token= _jwtTokenGenerator.GenerateJwtToken(user);
        
        return new AuthenticationResult(
            user,
            Token
        );
    }
}