using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AP.Entities.DataModels
{
    public partial class Order
    {
        [Key]
        public string SessionId { get; set; }

        public long CartId { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Price { get; set; }

        public string Status { get; set; }

        public string InvoicePdf { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
