//dto for register of presentation
namespace Contracts
{
    public record RegisterRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password
    );
}