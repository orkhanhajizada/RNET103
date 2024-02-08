namespace CodeFirstApp.Models;

public class Category
{
    public int CategoryID { get; set; }
    public string CategoryName { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public virtual ICollection<Product> Products { get; set; } = null!;
}