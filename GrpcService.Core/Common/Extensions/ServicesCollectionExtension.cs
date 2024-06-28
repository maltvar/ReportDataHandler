using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GrpcService.Core.Common.Extensions;

public static class ServicesCollectionExtension
{
    public static IServiceCollection ConfigureCore(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));

        return services;
    }
}