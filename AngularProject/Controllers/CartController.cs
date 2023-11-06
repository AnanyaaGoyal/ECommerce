using AP.Common;
using AP.Entities.DataModels;
using AP.Entities.ViewModels;
using AP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AngularProject.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Cart")]
    public class CartController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartController(ApplicationDbContext context, IWebHostEnvironment environment, IHttpContextAccessor httpContextAccessor) : base(environment)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("getCartItems")]
        public ApiResponseViewModel<CartModel> GetCartItems(long nUserId)
        {
            try
            {
                var query = _context.Carts.Where(cart => cart.CartId == nUserId).AsQueryable();
                var cartItems = query.Select(item => new CartItem()
                {
                    ProductDetails = new Product
                    {
                        ProductId = item.ProductId,
                        Price = item.Product.Price,
                        Name = item.Product.Name,
                        Description = item.Product.Description,
                        Mfd = item.Product.Mfd,
                        Image = item.Product.Image
                    },
                    Quantity = item.Quantity
                });
                var lstItems = cartItems.ToList();
                //calculating total cost
                int totalCost = 0;
                foreach (var item in lstItems)
                {
                    totalCost = totalCost + item.ProductDetails.Price * item.Quantity;
                }

                CartModel objModel = new CartModel
                {
                    CartItems = lstItems,
                    TotalCost = totalCost
                };
                return GenerateResponse.CreateResponse<CartModel>((int)HttpStatusCode.OK, null, objModel, null);
            }
            catch (Exception ex)
            {
                return GenerateResponse.CreateResponse<CartModel>((int)HttpStatusCode.InternalServerError, ex.Message, null, null);
            }
        }

        [HttpPost("changeQuantity")]
        public ApiResponseViewModel<string> ChangeQuantity(ProductQuantityModel objModel)
        {
            try
            {
                var cartItem = _context.Carts.FirstOrDefault(i => i.CartId == objModel.CartId && i.ProductId == objModel.ProductId);

                if (objModel.Operation == "Decrease")
                {
                    if (cartItem.Quantity == 1)
                    {
                        _context.Carts.Remove(cartItem);
                    }
                    else
                    {
                        cartItem.Quantity = cartItem.Quantity - 1;
                    }

                    _context.SaveChanges();
                }
                else
                {
                    var availableAmt = _context.Products.FirstOrDefault(p => p.ProductId == objModel.ProductId).Quantity;
                    if (availableAmt < cartItem.Quantity + 1)
                    {
                        return GenerateResponse.CreateResponse<string>((int)HttpStatusCode.BadRequest, "Requested quantity exceeds the available quantity", null, null);
                    }
                    else
                    {
                        cartItem.Quantity = cartItem.Quantity + 1;
                        _context.SaveChanges();
                    }
                }

                return GenerateResponse.CreateResponse<string>((int)HttpStatusCode.OK, null, null, null);
            }
            catch (Exception ex)
            {
                return GenerateResponse.CreateResponse<string>((int)HttpStatusCode.InternalServerError, ex.Message, null, null);
            }
        }

    }
}