using Domanin.Entities;

namespace Application.Common.Interfaces.Authentication;


// interface for jwttoken
public interface IJwtTokenGenerator
{
    string GenerateJwtToken(User user);
    
}