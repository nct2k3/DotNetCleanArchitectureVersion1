//dto for login of presentation
namespace Contracts
{
    public record LoginRequest(
        string Email,
        string Password
    );
}