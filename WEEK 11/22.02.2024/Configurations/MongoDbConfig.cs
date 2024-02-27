namespace Configurations;

public class MongoDbConfig
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Database { get; set; } = null!;

    public string? ConnectionString =>
        $"mongodb+srv://{UserName}:{Password}@cluster0.4imzwgp.mongodb.net//{Database}?retryWrites=true&w=majority";
}