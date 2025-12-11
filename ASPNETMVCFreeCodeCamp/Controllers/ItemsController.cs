using ASPNETMVCFreeCodeCamp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETMVCFreeCodeCamp.Controllers;

public class ItemsController : Controller
{
    // GET
    public IActionResult Overview()
    {
        ItemModel item = new ItemModel() {Name = "TestItem1"};
        return View(item);
    }
    
    // Input: Url Segments
    public IActionResult Edit(int id)
    {
        return Content("id is " + id);
    }
}