using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETMVCFreeCodeCamp.Models;

public class SerialNumberModel
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = "";
    
    public int? ItemId { get; set; }
    /**
     * One-to-one relationships have a reference navigation property in each class to the other class.
     * The ForeignKey Attribute can be applied to the DEPENDENT class to establish the relationship.
     */
    [ForeignKey(nameof(ItemId))]
    public ItemModel? Item { get; set; }
    
}