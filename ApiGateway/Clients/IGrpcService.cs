using ApiGateway.Models.GrpcRequests;

namespace ApiGateway.Clients;

public interface IGrpcService
{
    Task<long> ReadDate(ReadDateGrpcRequest request);
}
