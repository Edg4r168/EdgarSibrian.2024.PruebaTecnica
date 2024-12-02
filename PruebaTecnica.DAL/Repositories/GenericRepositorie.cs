using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PruebaTecnica.DAL.Repositories;

public class GenericRepositorie<TEntity> where TEntity : class
{
    private readonly DbContext _context;

    public GenericRepositorie(DbContext context)
    {
        _context = context;
    }

    public async Task<List<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();


    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
        => await _context.Set<TEntity>().FirstOrDefaultAsync(filter);


    public async Task<TEntity> CreateAsync(TEntity entity) 
    {
        _context.Set<TEntity>().Add(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }
}
