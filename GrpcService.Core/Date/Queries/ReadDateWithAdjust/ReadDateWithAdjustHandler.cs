using GrpcService.Core.Common.Utils;
using MediatR;

namespace GrpcService.Core.Date.Queries.ReadDateWithAdjust;

internal class ReadDateWithAdjustHandler : IRequestHandler<ReadDateWithAdjustQuery, long>
{
    public Task<long> Handle(ReadDateWithAdjustQuery request, CancellationToken cancellationToken)
    {
        DateTime date = EpochConverter.ConvertToDate(request.EpochTime);

        var targetDate = date.AddMonths(1);
        int daysInMonth = DateTime.DaysInMonth(targetDate.Year, targetDate.Month);
        int targetDay = daysInMonth < request.NextDayMonth ? daysInMonth : request.NextDayMonth;
        var resultDate = new DateTime(targetDate.Year, targetDate.Month, targetDay);

        return Task.FromResult(EpochConverter.ConvertToEpoch(resultDate));
    }
}
