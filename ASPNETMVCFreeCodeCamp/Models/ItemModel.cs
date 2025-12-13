using System.ComponentModel.DataAnnotations;

namespace ASPNETMVCFreeCodeCamp.Models;

public class ItemModel
{
    public int Id { get; set; }
    
    [MaxLength(100)] // TODO: Change to .env value or dbconfig
    public string Name { get; set; } = "";
    public double Price { get; set; }
    
    public int? SerialNumberId { get; set; }
    public SerialNumberModel? SerialNumber { get; set; }
}