using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApplication.Models;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;


    // üst kategoriye referans
    //[ForeignKey(nameof(MasterCategory))]
    public int? MasterCategoryId { get; set; }
    //public int? MasterCategoryId { get; set; }
    public virtual Category? MasterCategory { get; set; }


    // bir kategorinin, birden fazla alt kategorisi olabilür
    public virtual ICollection<Category> SubCategories { get; set; }
    public Category()
    {

        this.SubCategories = new HashSet<Category>();
    }
}
