using ApiGateway.Clients;

namespace ApiGateway.Common.Extensions;

public static class ServicesCollectionExtension
{
    public static IServiceCollection ConfigureGrpcClients(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.ConfigureGrpcServiceClient(configuration);

        return services;
    }

    private static IServiceCollection ConfigureGrpcServiceClient(this IServiceCollection services,
        IConfiguration configuration)
    {
        string endpoint = configuration.GetSection("GrpcService:Endpoint").Value
            ?? throw new ArgumentNullException("GrpcService:Endpoint");

        services.AddGrpcClient<DateReader.DateReaderClient>((services, options) =>
        {
            options.Address = new Uri(endpoint);
        });

        services.AddTransient<IGrpcService, GrpcService>();
        return services;
    }
}