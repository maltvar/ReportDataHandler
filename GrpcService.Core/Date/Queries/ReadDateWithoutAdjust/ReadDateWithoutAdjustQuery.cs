using MediatR;

namespace GrpcService.Core.Date.Queries.ReadDateWithoutAdjust;

public class ReadDateWithoutAdjustQuery : IRequest<long>
{
    public long EpochTime { get; }
    public int NextDayMonth { get; }

    public ReadDateWithoutAdjustQuery(long epochTime,
        int nextDayMonth)
    {
        EpochTime = epochTime;
        NextDayMonth = nextDayMonth;
    }
}
