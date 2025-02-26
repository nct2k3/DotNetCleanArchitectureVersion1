using MediatR;
using OneOf.Types;
using ErrorOr;
namespace Application.Service.Authentication;

public record RegisterCommand
    (string FirstName, string LastName,
        string Email, string Password): IRequest<ErrorOr<AuthenticationResult> >
;