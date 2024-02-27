namespace CategoryApi;
public static class ApiConfiguration
{
    public static void ApiServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("default"));
        });


        RedisConfiguration? redisConfiguration = configuration.GetSection("Redis").Get<RedisConfiguration>();
        string connectionString = redisConfiguration!.ConnectionString;
        string instanceName = redisConfiguration!.InstanceName;


        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(connectionString));
        services.AddSingleton<IRedisService>(provider => new RedisService(provider.GetRequiredService<IConnectionMultiplexer>(), instanceName));
    }
}
