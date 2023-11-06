using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AP.Entities.DataModels;

public partial class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public string? Description { get; set; }

    public int Quantity { get; set; }

    public DateTime Mfd { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

}
