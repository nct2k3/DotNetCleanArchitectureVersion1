using Application.Common.Errors;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domanin.Entities;

namespace Application.Service.Authentication;

public class PasswordMismatchException : Exception
{
    public PasswordMismatchException() : base("Passwords do not match") { }
}

public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("User with email address does not exist") { }
}


public class AuthenticationService : IAuthenticationService
{
    
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator ,IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
        
    public AuthenticationResult Login(string Email, string Password)
    {
        if (_userRepository.GetUserByEmail(Email) is not User user)
        {
            throw new Exception("User with email address does not exist");
        }

        if (user.Password != Password)
        {
            throw new Exception("Passwords do not match");
        }
        var Token= _jwtTokenGenerator.GenerateJwtToken(user);
        
        return new AuthenticationResult(
           user,
            Token
        );
    }


    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        if (_userRepository.GetUserByEmail(Email) is not null)
        {
            throw new DuplicateEmailException(); 
        }
        var user = new User
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Password = Password,
        };
        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateJwtToken(user);
        return new AuthenticationResult(user, token);
    }

}