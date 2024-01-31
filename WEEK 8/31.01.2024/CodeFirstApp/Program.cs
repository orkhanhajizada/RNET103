using CodeFirstApp.Data;
using CodeFirstApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeFirstApp;

public class Program
{
    
    private  readonly ICategoryService _categoryService;
        
    public Program(ICategoryService categoryService)
    {
        _categoryService = categoryService;

        var c = _categoryService.GetAllAsync().GetAwaiter().GetResult();
        foreach (var item in c)
        {
            Console.WriteLine(item.CategoryName);
        }
    }
    
    
    public static void Main()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection, configuration);
        
        
    }
    
    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
    }
}

