using Domanin.Entities;

namespace Application.Service.Authentication;

//Dto for authenticaton result
public record AuthenticationResult(
    User User,
    string Token
    
    
);