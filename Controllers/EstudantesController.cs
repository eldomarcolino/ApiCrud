using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDeRecarga.Context;
using SistemaDeRecarga.Model;

namespace SistemaDeRecarga.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EstudantesController : ControllerBase
    {
        private readonly IEstudantesBusiness _estudantesbusiness;
        private readonly AppDbContext _context;

        public EstudantesController(IEstudantesBusiness estudantesbusiness, AppDbContext context)
        {
            _estudantesbusiness = estudantesbusiness;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEstudantesAsync()
        {
            var students = await _estudantesbusiness.GetAllEstudantesAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstudantesByIdAsync(int id)
        {
            var students = await _estudantesbusiness.GetEstudantesByIdAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstudantesAsync(Estudantes estudante)
        {
            try
            {
                await _estudantesbusiness.CreateEstudantesAsync(estudante);

                var sucessResponse = new
                {
                    Success = true,
                    Message = "Estudante Cadastrado com sucesso",
                    Data = estudante
                };

                return StatusCode(StatusCodes.Status201Created, sucessResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstudantesAsync(int id, Estudantes estudante)
        {
            if (id != estudante.Id)
            {
                return BadRequest("ID do estudante não corresponde.");
            }

            try
            {
                await _estudantesbusiness.UpdateEstudantesAsync(estudante);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudantesAsync(int id)
        {
            try
            {
                await _estudantesbusiness.DeleteEstudantesAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
