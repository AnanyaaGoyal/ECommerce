using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AP.Entities.DataModels
{
    public partial class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CustomerId { get; set; }
        public string SessionId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        [ForeignKey("SessionId")]
        [JsonIgnore]
        public virtual Order? Order { get; set; }
    }
}
