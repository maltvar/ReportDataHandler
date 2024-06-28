using ApiGateway.Models.GrpcRequests;

namespace ApiGateway.Clients;

public class GrpcService : IGrpcService
{
    private readonly DateReader.DateReaderClient _client;

    public GrpcService(DateReader.DateReaderClient client)
    {
        _client = client;
    }

    public async Task<long> ReadDate(ReadDateGrpcRequest request)
    {
        //TODO: map request to grpc message.
        var grpcRequest = new DateRequest 
        {
            DayOfMonth = request.NextMonthDate,
            EpochTime = request.EpochTime,
            Adjust = request.Adjust
        };

        //TODO: Create a wrap<T> of grpc response
        var response = await _client.ReadDateAsync(grpcRequest);
        return response.EpochTime;
    }
}
