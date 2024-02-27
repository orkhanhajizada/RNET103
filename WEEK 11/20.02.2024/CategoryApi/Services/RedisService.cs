using StackExchange.Redis;

namespace CategoryApi.Services;

public class RedisService : IRedisService
{
    private readonly IDatabase _database;
    private readonly string _instanceName;

    public RedisService(IConnectionMultiplexer redis, string instanceName)
    {
        _database = redis.GetDatabase();
        _instanceName = instanceName;
    }

    public async Task<string> GetAsync(string key) => await _database.StringGetAsync($"{_instanceName}:{key}");

    public async Task SetAsync(string key, string value) =>
        await _database.StringSetAsync($"{_instanceName}:{key}", value);

    public async Task RemoveAsync(string key) => await _database.KeyDeleteAsync($"{_instanceName}:{key}");
}