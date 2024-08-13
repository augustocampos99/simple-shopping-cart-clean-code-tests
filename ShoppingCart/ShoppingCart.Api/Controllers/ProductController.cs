using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Contracts;
using ShoppingCart.Domain.Entities;
using ShoppingCart.Domain.Interfaces.Services;

namespace ShoppingCart.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int limit = 10;
            int skip = 0;

            if(!String.IsNullOrEmpty(Request.Query["limit"]) && !String.IsNullOrEmpty(Request.Query["skip"]))
            {
                limit = Int32.Parse(Request.Query["limit"]);
                skip = Int32.Parse(Request.Query["skip"]);
            }

            var result = await _productService.GetAllLimit(limit, skip);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductRequest productRequest)
        {
            var product = new Product
            {
                Title = productRequest.Title,
                Description = productRequest.Description,
                Price = productRequest.Price
            };

            var result = await _productService.Create(product);

            return Ok(result);
        }

    }
}
