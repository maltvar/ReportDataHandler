namespace ApiGateway.Common.Helpers;

public static class DateComposer
{
    public static DateTime ComposeDate(int? year, int? month, int? day)
    {
        DateTime now = DateTime.Now;

        int y = year.HasValue ? year!.Value : now.Year;
        int m = month.HasValue ? month!.Value : now.Month;
        int d = day.HasValue ? day!.Value : now.Day;

        return new DateTime(y, m, d);
    }
}
