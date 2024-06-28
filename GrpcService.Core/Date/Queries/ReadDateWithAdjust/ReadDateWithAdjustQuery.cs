using MediatR;

namespace GrpcService.Core.Date.Queries.ReadDateWithAdjust;

public class ReadDateWithAdjustQuery : IRequest<long>
{
    public long EpochTime { get; }
    public int NextDayMonth { get; }

    public ReadDateWithAdjustQuery(long epochTime,
        int nextDayMonth)
    {
        EpochTime = epochTime;
        NextDayMonth = nextDayMonth;
    }
}