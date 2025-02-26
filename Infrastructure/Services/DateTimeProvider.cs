using Application.Common.Interfaces.Services;

namespace ClassLibrary1.Services;

// creat date time 
public class DateTimeProvider: IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}