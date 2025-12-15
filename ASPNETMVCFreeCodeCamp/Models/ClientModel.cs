using System.ComponentModel.DataAnnotations;

namespace ASPNETMVCFreeCodeCamp.Models;

public class ClientModel
{
    public int Id { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }
    
    public List<ItemClientModel>? ItemClientModels { get; set; }

}