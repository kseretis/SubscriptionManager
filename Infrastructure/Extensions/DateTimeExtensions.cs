namespace Infrastructure.Extensions;

public static class DateTimeExtensions
{
    public static DateTimeOffset ToUniversalDateTimeOffset(this DateTime? dateTime)
    {
        return new DateTimeOffset(dateTime ?? DateTime.Now).ToUniversalTime();
    }

    public static DateTime ToLocalTimezone(this DateTimeOffset dateTimeOffset)
    {
        return dateTimeOffset.LocalDateTime;
    }
}
