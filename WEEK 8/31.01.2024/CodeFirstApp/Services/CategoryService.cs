using CodeFirstApp.Data;
using CodeFirstApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApp.Services;

public class CategoryService : ICategoryService
{ 
    private readonly ApplicationDbContext _context;
    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllAsync() => await _context.Categories.ToListAsync();
}