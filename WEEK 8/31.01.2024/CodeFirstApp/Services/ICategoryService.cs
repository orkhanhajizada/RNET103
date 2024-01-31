using CodeFirstApp.Models;

namespace CodeFirstApp.Services;

public interface ICategoryService
{
    Task<List<Category>> GetAllAsync();
}