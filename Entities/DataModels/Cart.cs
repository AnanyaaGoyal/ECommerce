using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AP.Entities.DataModels;

public partial class Cart
{
    public long CartId { get; set; }

    public long ProductId { get; set; }

    public int Quantity { get; set; }

    [ForeignKey("ProductId")]
    [JsonIgnore]
    public virtual Product? Product { get; set; }
}
