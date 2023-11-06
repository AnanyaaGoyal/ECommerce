using static AP.Common.GlobalEnum;

namespace AP.Entities.ViewModels
{
    public class ProductQuantityModel
    {
        public long ProductId { get; set; }
        public long CartId { get; set; }
        public string Operation { get; set; }
    }
}
