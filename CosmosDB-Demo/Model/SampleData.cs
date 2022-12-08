

using Newtonsoft.Json;

public class SampleData
{
    [JsonProperty("address")]
    public string? Address { get; set; }
    [JsonProperty("id")]
    public string? Id { get; set; }
    [JsonProperty("_rid")]
    public string? Rid { get; set; }    
    [JsonProperty("_self")]
    public string? Self { get; set; }
    [JsonProperty("_etag")]
    public string? Etag { get; set; }
    [JsonProperty("_attachments")]
    public string? Attachments { get; set; }
    [JsonProperty("_ts")]
    public int Ts { get; set; }

}
