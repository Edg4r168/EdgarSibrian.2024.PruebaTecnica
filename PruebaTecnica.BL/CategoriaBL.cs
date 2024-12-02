using PruebaTecnica.DAL.Repositories;
using PruebaTecnica.EN;

namespace PruebaTecnica.BL;

public class CategoriaBL
{
    private readonly GenericRepositorie<Categoria> _repositorie;

    public CategoriaBL(GenericRepositorie<Categoria> repositorie)
    {
        _repositorie = repositorie;
    }

    public async Task<List<Categoria>> GetAllAsync() => await _repositorie.GetAllAsync();


    public async Task<Categoria?> GetAsync(int id) => await _repositorie.GetAsync(c => c.Id == id);


    public async Task<Categoria?> CreateAsync(Categoria Categoria) => await _repositorie.CreateAsync(Categoria);

    
    public async Task<bool> UpdateAsync(Categoria categoria) => await _repositorie.UpdateAsync(categoria);


    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _repositorie.GetAsync(c => c.Id == id);
        return await _repositorie.DeleteAsync(category);
    }
}
