using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.DAL.DBContext;
using PruebaTecnica.DAL.Repositories;

namespace PruebaTecnica.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AgregarRepositorios(this IServiceCollection services, string connection)
    {
        services.AddDbContext<ProductosDBContext>(options =>
        {
            options.UseMySql(connection, ServerVersion.AutoDetect(connection));
        });

        services.AddTransient(typeof(GenericRepositorie<>));

        return services;
    }
}
