namespace ApiGateway.Validators;

public static class InputValidator
{
    public static void ValidateDate(int? year, int? month, int? day)
    {
        if (year.HasValue && year <= 0)
            throw new ArgumentOutOfRangeException(nameof(year));

        if ((month.HasValue) && (month < 1 || month > 12))
            throw new ArgumentOutOfRangeException(nameof(month));

        if ((day.HasValue) && (day < 1 || day > 31))
            throw new ArgumentOutOfRangeException(nameof(day));
    }

    public static void ValidateNextMonthDay(int nextMonthDay)
    {
        if (nextMonthDay < 1 || nextMonthDay > 31)
            throw new ArgumentOutOfRangeException(nameof(nextMonthDay));
    }
}