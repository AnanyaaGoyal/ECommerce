using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AP.Entities.DataModels
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DetaiId { get; set; }
        public string SessionId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("SessionId")]
        [JsonIgnore]
        public virtual Order Orders { get; set; }

        [ForeignKey("ProductId")]
        [JsonIgnore]
        public virtual Product Products { get; set; }
    }
}
