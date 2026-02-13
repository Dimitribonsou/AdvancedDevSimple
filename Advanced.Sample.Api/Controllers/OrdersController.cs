using AdvancedDevSample.API.Contracts;
using AdvancedDevSample.Application.Services;
using global::AdvancedDevSample.API.Contracts;
using global::AdvancedDevSample.Application.Services;
using Microsoft.AspNetCore.Mvc;
namespace AdvancedDevSample.Api.Controllers
{

    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _service;

        public OrdersController(OrderService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(CreateOrderRequest request)
        {
            var id = _service.Create(request.CustomerName, request.TotalAmount);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _service.GetAll()
                .Select(o => new OrderResponse(o.Id, o.CustomerName, o.TotalAmount, o.CreatedAt));

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var o = _service.GetById(id);
            return Ok(new OrderResponse(o.Id, o.CustomerName, o.TotalAmount, o.CreatedAt));
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateOrderRequest request)
        {
            _service.Update(id, request.CustomerName, request.TotalAmount);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }

}
