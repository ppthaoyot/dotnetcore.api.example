using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmileShop.API.DTOs.Product;
using SmileShop.API.Services.Product;

namespace SmileShop.API.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        #region Constructor
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _productService.GetById(id));
        }

        [HttpPost()]
        public async Task<IActionResult> Add(AddProductDto product)
        {
            return Ok(await _productService.Add(product));
        }

        [HttpPut()]
        public async Task<IActionResult> Update(UpdateProductDto product)
        {
            return Ok(await _productService.Update(product));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return Ok(await _productService.Remove(id));
        }
    }
}