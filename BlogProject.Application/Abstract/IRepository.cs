namespace BlogProject.Application.Repositories;
public interface IRepository<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task DeleteAsync(Guid id);
    Task<T?> UpdateAsync(Guid id, T entity);
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
}
