namespace Application.Service.Authentication;

// interface for authenticationservice
public interface IAuthenticationService
{
    AuthenticationResult Login(string Email, string Password);
    AuthenticationResult Register(string FirstName, string LastName, string Email, string Password);
}