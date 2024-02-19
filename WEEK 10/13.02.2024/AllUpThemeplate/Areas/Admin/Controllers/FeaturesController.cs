using AllUpThemeplate.Data;
using AllUpThemeplate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AllUpThemeplate.Areas.Admin.Controllers;

[Area("Admin")]
public class FeaturesController : Controller
{
    private readonly ApplicationDbContext _context;

    public FeaturesController(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        return View(await _context.Features.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ImageUrl,Title,Description")] Feature feature)
    {
        if (ModelState.IsValid)
        {
            _context.Add(feature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(feature);
    }


    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var feature = await _context.Features.FindAsync(id);
        if (feature == null)
        {
            return NotFound();
        }

        return View(feature);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ImageUrl,Title,Description")] Feature feature)
    {
        if (id != feature.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(feature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(feature);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var feature = await _context.Features
            .FirstOrDefaultAsync(m => m.Id == id);
        if (feature == null)
        {
            return NotFound();
        }

        return View(feature);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var feature = await _context.Features.FindAsync(id);

        if (feature == null)
            return NotFound();
        
        _context.Features.Remove(feature);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}