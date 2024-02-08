using MVCIntro.Models;

namespace MVCIntro.ViewModels;

public class CategoryVm
{
    public string Description { get; set; }
    public List<Category> Categories { get; set; }
}