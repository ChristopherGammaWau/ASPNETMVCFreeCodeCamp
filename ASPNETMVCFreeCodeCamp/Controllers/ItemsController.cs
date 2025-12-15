using ASPNETMVCFreeCodeCamp.Data;
using ASPNETMVCFreeCodeCamp.Models;
using ASPNETMVCFreeCodeCamp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCFreeCodeCamp.Controllers;

public class ItemsController : Controller
{
    private readonly MVCAppContext _context;
    
    public ItemsController(MVCAppContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<ItemModel> items = await _context.Items
            .Include(s => s.SerialNumber)
            .Include(c => c.Category)
            .Include(ic => ic.ItemClientModels)
            .ThenInclude(ic => ic.Client)
            .ToListAsync();
        return View(items);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        // ViewData["CategoryList"] = new SelectList(_context.Categories, "Id", "Name");
        
        return View(new CreateEditViewModel(new SelectList(_context.Categories, "Id", "Name")));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([Bind("Id, Name, Price, CategoryId")] ItemModel item)
    {
        if (ModelState.IsValid)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(new CreateEditViewModel(new SelectList(_context.Categories, "Id", "Name")));
    }
    
    // GET
    public IActionResult Overview()
    {
        ItemModel item = new ItemModel() {Name = "TestItem1"};
        return View(item);
    }
    
    // Input: Url Segments
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        ItemModel? item = await _context.Items.FirstOrDefaultAsync(item => item.Id == id);
        // Check is null
        if (item != null)
        {
            CreateEditViewModel viewModel = new CreateEditViewModel(new SelectList(_context.Categories, "Id", "Name"));
            viewModel.Item = item;
            return View(viewModel);
        }
        else
        {
            return StatusCode(404, "Item not found");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit([Bind("Id, Name, Price, CategoryId")] ItemModel item)
    {
        if (ModelState.IsValid)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        CreateEditViewModel viewModel = new CreateEditViewModel(new SelectList(_context.Categories, "Id", "Name"));
        viewModel.Item = item;
        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        ItemModel? item = await _context.Items.FindAsync(id);
        if (item != null)
        {
            // TODO: Replace with JS Toast in footer to notify operation status instead of dedicated View
            
            return View(item);
        }
        else
        {
            return StatusCode(404, "Item not found");
        }
    }
    
    // Redirects from a request to "Delete" action IF it's a POST request
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        ItemModel? item = await _context.Items.FindAsync(id);
        if (item != null)
        {
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return StatusCode(404, "Item not found");
        }
    }
}