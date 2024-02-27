namespace CategoryApi.Services;

public interface IRedisService
{
    public Task<string> GetAsync(string key);
    public Task SetAsync(string key, string value);
    public Task RemoveAsync(string key);
}