using DDD_SOLID.Application.Commands.CreateCall;
using DDD_SOLID.Application.Queries.GetAllCalls;
using DDD_SOLID.Application.Queries.GetCallById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDD_SOLID_API.Controllers.Pacientes
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallController : Controller
    {
        private readonly IMediator _mediator;

        public  CallController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCall([FromBody] CreateCallRequest request)
        {
            var command = new CreateCallCommand(request);
            var id = await _mediator.Send(command);
            return Ok(new {CallId = id});
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCallById(Guid  id)
        {
            var call = await _mediator.Send(new GetCallByIdQuery(id));
            if (call == null) return NotFound();
            return Ok(call);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCalls()
        {
            var calls = await _mediator.Send(new GetAllCallsQuery());
            return Ok(calls);
        }
    }
}
