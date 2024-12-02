using PruebaTecnica.DAL.Repositories;
using PruebaTecnica.EN;

namespace PruebaTecnica.BL;

public class ProductoBL
{
    private readonly GenericRepositorie<Producto> _repositorie;

    public ProductoBL(GenericRepositorie<Producto> repositorie)
    {
        _repositorie = repositorie;
    }

    public async Task<List<Producto>> GetAllAsync() => await _repositorie.GetAllAsync();


    public async Task<Producto?> GetAsync(int id) => await _repositorie.GetAsync(c => c.Id == id);


    public async Task<Producto?> CreateAsync(Producto producto) => await _repositorie.CreateAsync(producto);


    public async Task<bool> UpdateAsync(Producto producto) => await _repositorie.UpdateAsync(producto);


    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _repositorie.GetAsync(c => c.Id == id);
        return await _repositorie.DeleteAsync(product);
    }
}
