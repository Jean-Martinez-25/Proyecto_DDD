using DDD_SOLID.Application.Commands.CreateCustomer;
using DDD_SOLID.Application.Queries.GetAllCustomers;
using DDD_SOLID.Application.Queries.GetCustomersById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDD_SOLID_API.Controllers.Pacientes
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            var result = await _mediator.Send(request);
            return CreatedAtAction(nameof(GetCustomerById), new { id = result }, new { id = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var result = await _mediator.Send(new GetCustomerByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(result);
        }
    }
}
