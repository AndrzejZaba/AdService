using AdService.Application.Common.Interfaces;

namespace AdService.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.UtcNow;
}
