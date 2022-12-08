
public class CosmosDbService : ICosmosDbService
{
    private Container _container;
    public CosmosDbService(CosmosClient cosmosClient, string databaseName, string containerName)
    {
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }
    public async Task AddAsync(SampleData item)
    {
       await _container.CreateItemAsync(item);
    }

    public async Task DeleteAsync(string id)
    {
       await _container.DeleteItemAsync<SampleData>(id,new PartitionKey(id));
    }

    public async Task<SampleData> GetAsync(string id)
    {
        try
        {
            var response = await _container.ReadItemAsync<SampleData>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (CosmosException) //For handling item not found and other exceptions
        {
            return null;
        }
    }

    public async Task<IEnumerable<SampleData>> GetMultipleAsync(string queryString)
    {
        var query = _container.GetItemQueryIterator<SampleData>(new QueryDefinition(queryString));
        var results = new List<SampleData>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            results.AddRange(response.ToList());
        }
        return results;
    }

    public async Task UpdateAsync(string id, SampleData item)
    {
        await _container.UpsertItemAsync(item, new PartitionKey(id));
    }
}
