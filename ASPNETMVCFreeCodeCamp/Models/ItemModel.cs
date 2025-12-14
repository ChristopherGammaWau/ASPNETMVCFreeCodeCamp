using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETMVCFreeCodeCamp.Models;

public class ItemModel
{
    public int Id { get; set; }
    
    [MaxLength(100)] // TODO: Change to .env value or dbconfig
    public string Name { get; set; } = "";
    public double Price { get; set; }
    
    public int? SerialNumberId { get; set; }
    public SerialNumberModel? SerialNumber { get; set; }
    
    public int? CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public CategoryModel? Category { get; set; }
}