
namespace CosmosDB_Demo.Interfaces;
public interface ICosmosDbService 
{
    Task<IEnumerable<SampleData>> GetMultipleAsync(string query);
    Task<SampleData> GetAsync(string id);
    Task AddAsync(SampleData item);
    Task UpdateAsync(string id, SampleData item);
    Task DeleteAsync(string id);
}
