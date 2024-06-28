using MediatR;
using System;

namespace GrpcService.Core.Common.Utils;

public static class EpochConverter
{
    public static long ConvertToEpoch(DateTime dateTime)
    {
        DateTime utcDate = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        long epochTime = new DateTimeOffset(utcDate).ToUnixTimeSeconds();

        return epochTime;
    }

    public static DateTime ConvertToDate(long epochTime) =>
        DateTime.UnixEpoch.AddSeconds(epochTime);
}
