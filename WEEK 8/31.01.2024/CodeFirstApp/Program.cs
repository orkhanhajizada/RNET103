using CodeFirstApp.Data;
using CodeFirstApp.Models;
using CodeFirstApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console;

namespace CodeFirstApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var categoryService = services.GetRequiredService<ICategoryService>();


            var dbContext = services.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();

            Query1(dbContext);
            // var categories = await categoryService.GetAllAsync();
            // foreach (var catergory in categories)
            // {
            //     Console.WriteLine(catergory.CategoryName);
            // }
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            var configuration = hostContext.Configuration;

            services
                .AddDbContext<ApplicationDbContext>(options => options
                    .UseSqlServer(configuration
                        .GetConnectionString("DefaultConnection")
                    ));
            services.AddScoped<ICategoryService, CategoryService>();
        });


    private  static void Query1(ApplicationDbContext context)
    {   
        var products = context.Products
            .AsNoTracking()
            .Where(p => p.UnitPrice > 20 && p.UnitPrice < 50)
            .Include(p => p.Category)
            .AsEnumerable()
            .Select((p,index) => new
            {
                RowNumber = index+1,
                UrunaId = p.ProductID,
                UrunAdi = p.ProductName,
                UnitFiyat = p.UnitPrice,
                BirimStock =p.UnitsInStock,
                Kategory = p.Category?.CategoryName
            })
            .OrderBy(p => p.UnitFiyat)
            .ThenByDescending(p => p.BirimStock)
            .ToList();

        ToTable(products);
    }


    public static void Query2(ApplicationDbContext context)
    {
    }

    public static void Query3(ApplicationDbContext context)
    {
    }

    public static void Query4(ApplicationDbContext context)
    {
    }

    public static void ToTable<T>(List<T> entity)
    {
        var table = new Table();
        table.Border = TableBorder.Rounded;
        table.BorderStyle = new Style(Color.Blue);
        table.Expand();

        foreach (var property in typeof(T).GetProperties())
        {
            table.AddColumn($"[green]{property.Name}[/]");
        }

        foreach (var item in entity)
        {
            var values = new List<string>();
            foreach (var property in typeof(T).GetProperties())
            {
                values.Add($"[deepskyblue1]{property.GetValue(item)}[/]");
            }

            table.AddRow(values.ToArray());
        }

        //table rengini mavi yap
        
        AnsiConsole.Write(table);
    }
}