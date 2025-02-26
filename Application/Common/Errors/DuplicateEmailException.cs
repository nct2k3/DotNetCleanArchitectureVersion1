using System.Net;

namespace Application.Common.Errors;

public class DuplicateEmailException : Exception,IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string Title =>"The Email already exists .";
  
}