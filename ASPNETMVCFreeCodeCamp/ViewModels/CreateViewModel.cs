using ASPNETMVCFreeCodeCamp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNETMVCFreeCodeCamp.ViewModels;

public class CreateViewModel
{
    public readonly SelectList _categoryList;
    public ItemModel  Item { get; set; } = new ItemModel();

    public CreateViewModel(SelectList categoryList)
    {
        _categoryList = categoryList;
    }

    
}