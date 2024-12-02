using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.BL;
using PruebaTecnica.DAL;

namespace PruebaTecnica.IOC;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AgregarRepositorios(configuration.GetConnectionString("connection") ?? "");
        services.AddServices();

        return services;
    }
}
