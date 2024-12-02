using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.EN;

public class Producto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre del producto no puede exceder los 100 caracteres.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El precio del producto es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
    public decimal Precio { get; set; }


    [Required(ErrorMessage = "La categoría es obligatoria.")]
    [ForeignKey("Categoria")]
    public int IdCategoria { get; set; }

    public Categoria Categoria { get; set; }

}
