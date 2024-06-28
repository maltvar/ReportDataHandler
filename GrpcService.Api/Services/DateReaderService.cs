using Grpc.Core;
using GrpcService.Core.Date.Queries.ReadDateWithAdjust;
using GrpcService.Core.Date.Queries.ReadDateWithoutAdjust;
using MediatR;

namespace GrpcService.Api.Services;

public class DateReaderService : DateReader.DateReaderBase
{
    private readonly IMediator _mediator; // TODO: Inherit from base
    private readonly ILogger<DateReaderService> _logger;

    public DateReaderService(ILogger<DateReaderService> logger, 
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public override async Task<DateReply> ReadDate(DateRequest request, ServerCallContext context)
    {
        long result = -1;

        if (request.Adjust)
            result = await _mediator.Send(new ReadDateWithAdjustQuery(request.EpochTime, request.DayOfMonth));
        else
            result = await _mediator.Send(new ReadDateWithoutAdjustQuery(request.EpochTime, request.DayOfMonth));

        if (result == -1)
            throw new InvalidOperationException("Could not send mediatr request");

        return new DateReply
        {
            EpochTime = result
        };
    }
}