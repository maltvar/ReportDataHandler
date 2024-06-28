namespace ApiGateway.Models.GrpcRequests;

public record ReadDateGrpcRequest(
    int NextMonthDate,
    long EpochTime,
    bool Adjust);