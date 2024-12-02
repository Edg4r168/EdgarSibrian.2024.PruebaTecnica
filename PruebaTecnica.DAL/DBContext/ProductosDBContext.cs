using Microsoft.EntityFrameworkCore;
using PruebaTecnica.EN;

namespace PruebaTecnica.DAL.DBContext;

public class ProductosDBContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<Producto> Productos { get; set; }

    public ProductosDBContext(DbContextOptions<ProductosDBContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
