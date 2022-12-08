namespace CosmosDB_Demo.Repository;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetMultipleAsync(string query);
    Task<T> GetAsync(string id);
    Task AddAsync(T item);
    Task UpdateAsync(string id, T item);
    Task DeleteAsync(string id);
}
