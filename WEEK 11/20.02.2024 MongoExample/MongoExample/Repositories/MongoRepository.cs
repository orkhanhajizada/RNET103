using MongoDB.Driver;

namespace MongoExample.Repositories;

public class MongoRepository<T> : IRepository<T> where T : class, new()
{
    private readonly IMongoCollection<T> _collection;
    private readonly IConfiguration _configuration;
    public MongoRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        var client = new MongoClient(_configuration["MongoDB:ConnectionString"]);
        var database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
        _collection = database.GetCollection<T>(typeof(T).Name.ToLower() + "s");
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<T> GetByIdAsync(string id)
    {
        return await _collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(string id, T entity)
    {
        await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), entity);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
    }
}