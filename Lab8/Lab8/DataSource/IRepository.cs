namespace Lab8.DataSource;

public interface IRepository<T>
{
    Task<IReadOnlyCollection<T>> GetAllAsync();

    Task<T> GetAsync(string id);

    Task AddAsync(T entity);

    Task EditAsync(T entity);

    Task DeleteAsync(string id);
}