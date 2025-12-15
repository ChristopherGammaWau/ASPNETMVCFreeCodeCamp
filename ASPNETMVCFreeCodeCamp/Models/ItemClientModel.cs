namespace ASPNETMVCFreeCodeCamp.Models;

public class ItemClientModel
{
    public int ItemId { get; set; }
    public ItemModel Item { get; set; }
    
    public int ClientId { get; set; }
    public ClientModel Client { get; set; }
}