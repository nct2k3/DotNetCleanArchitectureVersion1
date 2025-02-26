using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Services;
using Domanin.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace ClassLibrary1.Authentication;

public class JwtTokenGenerator: IJwtTokenGenerator
{
    
    private readonly JwtSettings _jwtSettings;
    
    
    // create token whit name id and time 
    private IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings>settings)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = settings.Value;
    }
    
    public string GenerateJwtToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256
        );


        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securytyToker = new JwtSecurityToken(
            issuer:_jwtSettings.Issuer,
            audience:_jwtSettings.Audience,
            expires:_dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpriryMinutes),
            claims: claims,
            signingCredentials: signingCredentials);
        return new JwtSecurityTokenHandler().WriteToken(securytyToker);
        
    }
}