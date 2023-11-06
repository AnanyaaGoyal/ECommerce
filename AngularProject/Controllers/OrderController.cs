using AP.Common;
using AP.Entities.DataModels;
using AP.Entities.ViewModels;
using AP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AngularProject.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Order")]
    public class OrderController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context, IWebHostEnvironment environment) : base(environment)
        {
            _context = context;
        }

        [HttpGet("GetOrders")]
        public ApiResponseViewModel<OrderModel> GetOrders(long cartId)
        {
            try
            {
                var orders = new List<OrderModel>();
                var orderList = _context.Orders.Include(o => o.OrderDetails).ThenInclude(p => p.Products).Where(o => o.CartId == cartId).ToList();
                foreach (var order in orderList)
                {
                    List<string> images = new List<string>();
                    foreach (var product in order.OrderDetails)
                    {
                        images.Add(product.Products.Image);
                    }
                    orders.Add(new OrderModel()
                    {
                        SessionId = order.SessionId,
                        Status = order.Status,
                        Images = images
                    });
                }

                return GenerateResponse.CreateResponse<OrderModel>((int)HttpStatusCode.OK, null, null, orders);
            }
            catch (Exception ex)
            {
                return GenerateResponse.CreateResponse<OrderModel>((int)HttpStatusCode.InternalServerError, ex.Message, null, null);
            }
        }

        [HttpGet("GetOrderDetails")]
        public ApiResponseViewModel<CartModel> GetOrderDetails(string sSessionId)
        {
            try
            {
                var products = _context.OrderDetails.Include(o => o.Products).Where(o => o.SessionId == sSessionId).ToList();
                List<CartItem> items = new List<CartItem>();
                foreach (var product in products)
                {
                    var productDetails = new Product()
                    {
                        ProductId = product.ProductId,
                        Price = product.Products.Price,
                        Name = product.Products.Name,
                        Image = product.Products.Image,
                        Quantity = product.Products.Quantity
                    };
                    items.Add(new CartItem()
                    {
                        ProductDetails = productDetails,
                        Quantity = product.Quantity
                    });
                }

                //calculating total cost
                int totalCost = 0;
                foreach (var item in items)
                {
                    totalCost = totalCost + item.ProductDetails.Price * item.Quantity;
                }

                CartModel objModel = new CartModel
                {
                    CartItems = items,
                    TotalCost = totalCost,
                    CreatedDate = _context.Orders.FirstOrDefault(o=>o.SessionId == sSessionId).CreatedAt,
                    OrderId = _context.Orders.FirstOrDefault(o => o.SessionId == sSessionId).SessionId,
                    InvoicePdf = _context.Orders.FirstOrDefault(o => o.SessionId == sSessionId).InvoicePdf
                };

                return GenerateResponse.CreateResponse<CartModel>((int)HttpStatusCode.OK, null, objModel, null);
            }
            catch (Exception ex)
            {
                return GenerateResponse.CreateResponse<CartModel>((int)HttpStatusCode.InternalServerError, ex.Message, null, null);
            }
        }
    }
}
