namespace PruebaTecnica.EN;

public class Categoria
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public List<Producto> ProductosNavegacion { get; set; }
}
