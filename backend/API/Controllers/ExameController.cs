using backend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static backend.Application.Command.ExameCommand;

namespace backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateExame([FromBody] CreateExameCommand exame)
        {
            if (exame == null)
            {
                return BadRequest("Exame cannot be null");
            }

            var id = await _mediator.Send(exame);
            return Ok(new { Id = id });
        }
    }
}
