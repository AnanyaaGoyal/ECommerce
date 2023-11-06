using AP.Common;
using AP.Entities.DataModels;
using AP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AngularProject.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Product")]
    public class ProductController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context, IWebHostEnvironment environment) : base(environment)
        {
            _context = context;
        }

        [HttpGet("getProducts")]
        public ApiResponseViewModel<Product> GetAllProducts()
        {
            try
            {
                var products = _context.Products.ToList();
                return GenerateResponse.CreateResponse<Product>((int)HttpStatusCode.OK, null, null, products);
            }
            catch (Exception ex)
            {
                return GenerateResponse.CreateResponse<Product>((int)HttpStatusCode.InternalServerError, ex.Message, null, null);
            }
        }

        [HttpGet("getCartCount")]
        public ApiResponseViewModel<int?> GetCartCount(long nUserId)
        {
            try
            {
                var cartCount = _context.Carts.Where(c => c.CartId == nUserId).Sum(c => c.Quantity);
                return GenerateResponse.CreateResponse<int?>((int)HttpStatusCode.OK, null, cartCount, null);
            }
            catch (Exception ex)
            {
                return GenerateResponse.CreateResponse<int?>((int)HttpStatusCode.InternalServerError, ex.Message, 0, null);
            }
        }

        [HttpGet("addToCart")]
        public ApiResponseViewModel<string> AddToCart(long productId, long userId)
        {
            try
            {
                var userCart = _context.Carts.FirstOrDefault(c => c.CartId == userId && c.ProductId == productId);
                if (userCart != null)
                {
                    userCart.Quantity = userCart.Quantity + 1;
                    _context.SaveChanges();
                }

                //add cart
                _context.Carts.Add(new Cart()
                {
                    CartId = userId,
                    ProductId = productId,
                    Quantity = 1
                });
                _context.SaveChanges();
                return GenerateResponse.CreateResponse<string>((int)HttpStatusCode.OK, "Item added to cart", null, null);
            }
            catch (Exception ex)
            {
                return GenerateResponse.CreateResponse<string>((int)HttpStatusCode.InternalServerError, ex.Message, null, null);
            }
        }
    }
}
