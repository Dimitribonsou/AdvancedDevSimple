using AdvancedDevSample.Application.Services;
using AdvancedDevSample.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedDevSample.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpPut("{id}/price")]
        public IActionResult ChangePrice(Guid id, [FromBody] decimal request)
        {
            try
            {
                _productService.ChangeProductPrice(id, request);
                return NoContent();//204
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
          => Ok(_productService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_productService.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(CreateProductRequest request)
        {
            try
            {
                var id = _productService.Create(request.Name, request.Price, request.IsActive);
                return CreatedAtAction(nameof(GetById), new { id }, null);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateProductRequest request)
        {
            try
            {
                _productService.Update(id, request.Name, request.Price, request.IsActive);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _productService.Delete(id);
            return NoContent();
        }
    }

    public record CreateProductRequest(string Name, decimal Price, bool IsActive);
    public record UpdateProductRequest(string Name, decimal Price, bool IsActive);
}
    

