using Microsoft.Extensions.DependencyInjection;

namespace PruebaTecnica.BL;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<CategoriaBL>();
        services.AddScoped<ProductoBL>();

        return services;
    }
}
