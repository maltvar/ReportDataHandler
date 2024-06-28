using GrpcService.Core.Common.Utils;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GrpcService.Core.Date.Queries.ReadDateWithoutAdjust;

public class ReadDateWithoutAdjustHandler : IRequestHandler<ReadDateWithoutAdjustQuery, long>
{
    public Task<long> Handle(ReadDateWithoutAdjustQuery request, CancellationToken cancellationToken)
    {
        DateTime date = EpochConverter.ConvertToDate(request.EpochTime);

        bool found = false;
        var tempDate = date;
        var resultDate = DateTime.MinValue;

        do
        {
            var targetDate = tempDate.AddMonths(1);
            int daysInTargetMonth = DateTime.DaysInMonth(targetDate.Year, targetDate.Month);

            if (daysInTargetMonth >= request.NextDayMonth)
            {
                resultDate = new DateTime(targetDate.Year, targetDate.Month, request.NextDayMonth);
                found = true;
            }

            tempDate = targetDate;
        }
        while (!found);

        return Task.FromResult(EpochConverter.ConvertToEpoch(resultDate));
    }
}
