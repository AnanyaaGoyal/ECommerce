using AP.Entities.DataModels;
using Stripe.Checkout;

namespace AngularProject.Helper
{
    public class StripeService
    {
        private readonly ILogger<StripeService> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public StripeService(ILogger<StripeService> logger, IHttpContextAccessor contextAccessor, IConfiguration configuration, HttpClient httpClient)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<string> CheckOut(int price, List<Product> lstProducts)
        {
            try
            {
                var baseUrl = _configuration.GetValue<string>("angularBaseUrl") + "orders";
                var lineItems = new List<SessionLineItemOptions>();
                foreach(var product in lstProducts)
                {
                    lineItems.Add(new SessionLineItemOptions()
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = product.Price * 100,
                            Currency = "USD",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = product.Name,
                                Description = product.Description
                            }
                        },
                        Quantity = product.Quantity,
                    });
                }

                var options = new SessionCreateOptions
                {
                    SuccessUrl = $"{baseUrl}/success/" + "{CHECKOUT_SESSION_ID}",
                    CancelUrl = baseUrl + "/canceled",
                    PaymentMethodTypes = new List<string>
                    {
                        "card"
                    },
                    LineItems = lineItems,
                    Mode = "payment",
                    InvoiceCreation = new SessionInvoiceCreationOptions { Enabled = true },
                };

                var service = new SessionService();
                var session = await service.CreateAsync(options);
                return session.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError("error into Stripe service on checkOut() " + ex.Message);
                throw;
            }
        }
    }
}
