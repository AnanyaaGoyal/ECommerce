using AngularProject.Helper;
using AP.Common;
using AP.Entities.DataModels;
using AP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;
using System.Net;

namespace AngularProject.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Payment")]
    public class PaymentController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly StripeService _stripeService;

        public PaymentController(ApplicationDbContext context, IWebHostEnvironment environment, StripeService stripeService, IConfiguration configuration) : base(environment)
        {
            _context = context;
            _stripeService = stripeService;
        }

        [HttpPost("placeOrder/{cartId}")]
        public async Task<ApiResponseViewModel<string>> PlaceOrder([FromRoute] long cartId)
        {
            try
            {
                //calculate total amount
                int totalCost = 0;
                var productsInCart = _context.Carts.Include(c => c.Product).Where(c => c.CartId == cartId).ToList();
                List<Product> sessionProducts = new List<Product>();
                foreach (var product in productsInCart)
                {
                    totalCost = totalCost + product.Quantity * product.Product.Price;
                    sessionProducts.Add(new Product
                    {
                        Name = product.Product.Name,
                        Price = product.Product.Price,
                        Quantity = product.Quantity
                    });
                }

                //get sessionId using the service created
                var sessionId = await _stripeService.CheckOut(totalCost, sessionProducts);

                //insert order details wit sessionId in db
                Order orderModel = new Order
                {
                    SessionId = sessionId,
                    CreatedAt = DateTime.Now,
                    Price = totalCost,
                    CartId = cartId,
                    Status = "Processing",
                    InvoicePdf = "Invoice pdf"
                };
                _context.Orders.Add(orderModel);

                foreach (var product in productsInCart)
                {
                    OrderDetails detail = new OrderDetails
                    {
                        SessionId = sessionId,
                        ProductId = product.ProductId,
                        Quantity = product.Quantity,
                    };
                    _context.OrderDetails.Add(detail);
                }
                _context.SaveChanges();

                //return sessionId
                return GenerateResponse.CreateResponse<string>((int)HttpStatusCode.OK, null, sessionId, null);

            }
            catch (Exception ex)
            {
                return GenerateResponse.CreateResponse<string>((int)HttpStatusCode.InternalServerError, ex.Message, null, null);
            }
        }

        //call this api when payment is successful
        [HttpGet("success/{sessionId}")]
        public ApiResponseViewModel<string> CheckoutSuccess([FromRoute] string sessionId)
        {
            try
            {
                var sessionService = new SessionService();
                var session = sessionService.Get(sessionId);
                var invoiceId = session.InvoiceId;
                var invoiceService = new Stripe.InvoiceService();
                var invoiceDetails = invoiceService.Get(invoiceId);
                Customer customer = new Customer()
                {
                    SessionId = session.Id,
                    CustomerName = session.CustomerDetails.Name,
                    CustomerEmail = session.CustomerDetails.Email,
                };
                _context.Customers.Add(customer);

                //change order status and invoice pdf url
                var order = _context.Orders.FirstOrDefault(o => o.SessionId == sessionId);
                order.Status = "Placed";
                order.InvoicePdf = invoiceDetails.HostedInvoiceUrl;


                //remove items from cart
                var cartItems = _context.Carts.Where(c => c.CartId == order.CartId).ToList();
                _context.Carts.RemoveRange(cartItems);

                //change quantity in products table
                var orderItems = _context.OrderDetails.Where(o => o.SessionId == sessionId).ToList();
                foreach (var item in orderItems)
                {
                    var product = _context.Products.FirstOrDefault(context => context.ProductId == item.ProductId);
                    product.Quantity -= item.Quantity;
                }
                _context.SaveChanges();

                return GenerateResponse.CreateResponse<string>((int)HttpStatusCode.OK, "Payment successful!!", null, null);
            }
            catch (Exception ex)
            {
                return GenerateResponse.CreateResponse<string>((int)HttpStatusCode.InternalServerError, ex.Message, null, null);
            }
        }

    }
}
