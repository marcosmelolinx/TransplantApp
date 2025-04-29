using backend.Domain.Entities;
using backend.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static backend.Application.Command.ExameCommand;

namespace backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;

        public ExameController(IMediator mediator, ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;  // Inicializa o _context
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

        [HttpGet("test-db")]
        public async Task<IActionResult> TestDbConnection()
        {
            try
            {
                var count = await _context.Exames.CountAsync();
                return Ok($"Conexão bem-sucedida! Exames no banco: {count}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na conexão com o banco de dados: {ex.Message}");
            }
        }
    }

}
