

// const connectionString  ="Server=localhost;Database=Northwind;User Id=sa;Password=reallyStrongPwd123";

// dotnet ef dbcontext scaffold "Server=localhost;Database=Northwind;User Id=sa;Password=reallyStrongPwd123; TrustServerCertificate=True;"
// Microsoft.EntityFrameworkCore.SqlServer -o Models -t Categories  -t Products 


// Scafold-DbContext "Server=localhost;Database=Northwind;User Id=sa;Password=reallyStrongPwd123"
// Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context NorthwindContext -Force


using EFCoreDbFirst.Models;

namespace EFCoreDbFirst;

public  class Program
{
    
    public static void Main()
    {
        NorthwindContext context = new();
        
        //Create a new category
        Category newCategory = new()
        {
            CategoryName = "New Category22",
            Description = "New Description22"
        };
        
        context.Categories.Add(newCategory);
        context.SaveChanges();
        
        //Update the category
        
        var categoryToUpdate = context.Categories.Find(newCategory.CategoryId);
        categoryToUpdate.CategoryName = "Updated Category";
        categoryToUpdate.Description = "Updated Description";
        
        context.SaveChanges();
        
        
        var categories = context.Categories.ToList();
        
        foreach(var category in categories)
        {
            Console.WriteLine($"{category.CategoryId} {category.CategoryName} {category.Description}");
        }

        
    }
}