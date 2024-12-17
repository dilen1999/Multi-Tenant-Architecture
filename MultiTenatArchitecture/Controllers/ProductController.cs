using Microsoft.AspNetCore.Mvc;
using MultiTenatArchitecture.Services;
using MultiTenatArchitecture.Services.DTO;

namespace MultiTenatArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async  Task<IActionResult> Get([FromQuery] string tenantId)
        {
            if (string.IsNullOrEmpty(tenantId))
            {
                return BadRequest("TenantId is required.");
            }
            var list = _productService.GetAllProducts(tenantId);
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Post(CreateProductRequest request)
        {
            if (string.IsNullOrEmpty(request.TenantId))
            {
                return BadRequest("TenantId is required.");
            }
            var result = _productService.CreateProduct
                (request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.DeleteProduct(id);
            return Ok(result);
        }
    }
}
