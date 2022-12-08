

namespace CosmosDB_Demo.Model;
public class Employee
{
    [JsonProperty("id")]
    public string? Id { get; set; }
    [JsonProperty("name")]
    public string? Name { get; set; }
    [JsonProperty("salary")]
    public decimal Salary  { get; set; }
    [JsonProperty("department")]
    public string? Department { get; set; }
}
