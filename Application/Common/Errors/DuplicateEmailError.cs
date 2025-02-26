using System.Net;
using FluentResults;
namespace Application.Common.Errors;

public record struct  DuplicateEmailError:IError
{
    private IError _errorImplementation;
    public List<IError> Reasons => throw new NotImplementedException();
    public string Message => throw new NotImplementedException();
    public Dictionary<string, object> Metadata { get; }
    public Dictionary<String, Object>? Data => throw new NotImplementedException();
    
}