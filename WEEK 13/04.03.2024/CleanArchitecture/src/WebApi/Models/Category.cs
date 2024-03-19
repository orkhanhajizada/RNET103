namespace CleanArchitecture.WebApi.Models;

/// <summary>
/// Category
/// </summary>
public class Category
{
    /// <summary>
    /// CategoryID
    /// </summary>
    public int CategoryID { get; set; }

    /// <summary>
    /// CategoryName
    /// </summary>
    public string CategoryName { get; set; } = null!;

    /// <summary>
    /// Description
    /// </summary>
    public string? Description { get; set; }
}

