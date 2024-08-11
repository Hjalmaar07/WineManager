namespace WineManager.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<T?> GetByIdAsync(Guid id);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}
