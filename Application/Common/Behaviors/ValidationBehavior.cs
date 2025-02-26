/*using Application.Service.Authentication;
using FluentValidation;
using MediatR;
using OneOf.Types;


namespace Application.Common.Behavios;
public class Error
{
    public string Code { get; }
    public string Message { get; }

    private Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static Error Validation(string propertyName, string errorMessage)
    {
        return new Error($"ValidationError:{propertyName}", errorMessage);
    }
}

public class ValidationRegisterCommandBehavior:
    IPipelineBehavior<RegisterCommand,AuthenticationResult>
{
    private readonly IValidator<RegisterCommand> _registerCommandValidator;

    public ValidationRegisterCommandBehavior(IValidator<RegisterCommand> registerCommandValidator)
    {
        _registerCommandValidator = registerCommandValidator;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand request, 
        RequestHandlerDelegate<AuthenticationResult> next,
        CancellationToken cancellationToken
        )
    {
        var validationResult = await _registerCommandValidator.ValidateAsync(request);
        if (validationResult.IsValid)
        {
            return await next();
        }
        var errors = validationResult.Errors
            .ConvertAll(error => Error.Validation(error.PropertyName, error.ErrorMessage));


        // Throw hoặc xử lý lỗi theo cách của bạn
       // return errors;
    }
}*/