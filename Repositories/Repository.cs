using Microsoft.EntityFrameworkCore;
using WineManager.Data;

namespace WineManager.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected InMemoryDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(InMemoryDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        _context.Entry(entity).Reload();
        return entity;
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        await _context.Entry(entity).ReloadAsync();
        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
