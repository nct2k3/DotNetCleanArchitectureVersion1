using Application.Service.Authentication;
using ErrorOr;
namespace Application.Authentication.Quries.Login;

using MediatR;
using OneOf.Types;



public record LoginQuery(string Email, string Password): IRequest<ErrorOr<AuthenticationResult >>
;