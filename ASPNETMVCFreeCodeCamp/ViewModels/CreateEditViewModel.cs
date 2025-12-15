using ASPNETMVCFreeCodeCamp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNETMVCFreeCodeCamp.ViewModels;

public class CreateEditViewModel
{
    public readonly SelectList _categoryList;
    public ItemModel  Item { get; set; } = new ItemModel();

    public CreateEditViewModel(SelectList categoryList)
    {
        _categoryList = categoryList;
    }

    
}