namespace Application.Common.Interfaces.Services;


//inter face for datetime
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}