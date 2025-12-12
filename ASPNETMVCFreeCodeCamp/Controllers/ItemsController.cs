using ASPNETMVCFreeCodeCamp.Data;
using ASPNETMVCFreeCodeCamp.Models;
using Microsoft.AspNetCore.Mvc;
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
        List<ItemModel> items = await _context.Items.ToListAsync();
        return View(items);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([Bind("Id, Name, Price")] ItemModel item)
    {
        if (ModelState.IsValid)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(item);
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
            return View(item);
        }
        else
        {
            return StatusCode(404, "Item not found");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit([Bind("Id, Name, Price")] ItemModel item)
    {
        if (ModelState.IsValid)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(item);
    }
}