using ApiCrud.Model;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeRecarga.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoBusiness _cursoBusiness;

        public CursoController(ICursoBusiness cursoBusiness)
        {
            _cursoBusiness = cursoBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCursoAsync()
        {
            var cursos = await _cursoBusiness.GetAllCursoAsync();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCursoByIdAsync(int id)
        {
            var cursos = await _cursoBusiness.GetCursoByIdAsync(id);
            if (cursos == null)
            {
                return NotFound();
            }
            return Ok(cursos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCursoAsync(Curso curso)
        {
            try
            {
                await _cursoBusiness.CreateCursoAsync(curso);
                return CreatedAtAction(nameof(GetCursoByIdAsync), new { id = curso.Id }, curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCursoAsync(int id, Curso curso)
        {
            if (id != curso.Id)
            {
                return BadRequest("ID do curso não corresponde.");
            }

            try
            {
                await _cursoBusiness.UpdateCursoAsync(curso);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCursoAsync(int id)
        {
            try
            {
                await _cursoBusiness.DeleteCursoAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
