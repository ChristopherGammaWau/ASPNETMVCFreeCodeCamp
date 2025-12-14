namespace ASPNETMVCFreeCodeCamp.Models;

public class CategoryModel
{
    public int Id { get; set; }
    public string? Name { get; set; } = "";
    public List<ItemModel>? Items { get; set; }
}