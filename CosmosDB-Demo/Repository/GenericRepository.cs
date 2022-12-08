

namespace CosmosDB_Demo.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private Container _container;

    public GenericRepository(CosmosClient cosmosClient, string databaseName, string containerName)
    {
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }

    public async Task AddAsync(T item)
    {
        await _container.CreateItemAsync(item);
    }

    public async Task DeleteAsync(string id)
    {
        await _container.DeleteItemAsync<T>(id, new PartitionKey(id));
    }

    public async Task<T> GetAsync(string id)
    {
        try
        {
            var response = await _container.ReadItemAsync<T>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (CosmosException) 
        {
            return null;
        }
    }

    public async Task<IEnumerable<T>> GetMultipleAsync(string queryString)
    {
        var query = _container.GetItemQueryIterator<T>(new QueryDefinition(queryString));
        var results = new List<T>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            results.AddRange(response.ToList());
        }
        return results;
    }

    public async Task UpdateAsync(string id, T item)
    {
        await _container.UpsertItemAsync(item, new PartitionKey(id));
    }
}
