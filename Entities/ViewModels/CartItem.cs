using AP.Entities.DataModels;

namespace AP.Entities.ViewModels
{
    public class CartItem
    {
        public Product ProductDetails { get; set; }

        public int Quantity { get; set; }
    }
}
