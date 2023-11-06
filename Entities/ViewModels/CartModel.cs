namespace AP.Entities.ViewModels
{
    public class CartModel
    {
        public List<CartItem> CartItems { get; set; }

        public int TotalCost { get; set; }

        //for order details
        public string? OrderId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string InvoicePdf { get; set; }
    }
}
