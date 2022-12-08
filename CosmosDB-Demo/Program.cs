
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<ICosmosDbService>(options =>
{
    string url = builder.Configuration.GetSection("AzureCosmosDbSettings").GetValue<string>("url");
    string primaryKey = builder.Configuration.GetSection("AzureCosmosDbSettings").GetValue<string>("key");
    string dbName = builder.Configuration.GetSection("AzureCosmosDbSettings").GetValue<string>("DatabaseName");
    string containerName = builder.Configuration.GetSection("AzureCosmosDbSettings").GetValue<string>("container");
    var cosmosClient = new CosmosClient(url, primaryKey);

    return new CosmosDbService(cosmosClient, dbName, containerName);
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();

