//Dto for data authen of presentation
namespace Contracts
{
    public record AuthenticationResponse(
        Guid Id,
        string FistName,
        string LastName,
        string Email,
        string Token


    );
}