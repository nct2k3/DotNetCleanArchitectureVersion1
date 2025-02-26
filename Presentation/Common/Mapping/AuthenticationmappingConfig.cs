using Application.Authentication.Quries.Login;
using Application.Service.Authentication;
using Contracts;
using Mapster;

namespace WebApplication3.Common.Mapping;

public class AuthenticationmappingConfig:IRegister
{
    public void Register(TypeAdapterConfig config)
    {
    
        config.NewConfig<RegisterRequest,RegisterCommand>();
        config.NewConfig<LoginRequest,LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map( dest =>dest
            ,src => src.User
            );
        
    }
}