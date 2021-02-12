using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmileShop.API.DTOs.ProductGroup;
using SmileShop.API.Services.ProductGroup;

namespace SmileShop.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/productgroup")]
    public class ProductGroupController : ControllerBase
    {
        #region Constructor
        private readonly IProductGroupService _pgService;

        public ProductGroupController(IProductGroupService pgService)
        {
            _pgService = pgService;
        }
        #endregion

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _pgService.GetAll());
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Filter([FromQuery] FilterProductGroup filter)
        {
            return Ok(await _pgService.Filter(filter));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _pgService.GetById(id));
        }

        [HttpPost()]
        public async Task<IActionResult> Add(AddProductGroupDto productGroup)
        {
            return Ok(await _pgService.Add(productGroup));
        }

        [HttpPut("{productGroupId}")]
        public async Task<IActionResult> Update(int productGroupId, UpdateProductGroupDto productGroup)
        {
            return Ok(await _pgService.Update(productGroupId, productGroup));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return Ok(await _pgService.Remove(id));
        }
    }
}