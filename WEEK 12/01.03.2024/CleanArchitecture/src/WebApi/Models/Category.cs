using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.WebApi.Models;
public class Category
{
    public int CategoryID { get; set; } 
    public string CategoryName { get; set; } = null!;
    public string? Description { get; set; }
}
