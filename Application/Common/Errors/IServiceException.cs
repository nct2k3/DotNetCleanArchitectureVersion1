using System.Net;

namespace Application.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string Title { get; }
    
}