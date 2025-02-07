using ApiCrud.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsBusiness _studentsbusiness;

        public StudentsController(IStudentsBusiness studentsbusiness)
        {
            _studentsbusiness = studentsbusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentAsync()
        {
            var students = await _studentsbusiness.GetAllStudentAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var students = await _studentsbusiness.GetByIdAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync(Students estudante)
        {
            try
            {
                await _studentsbusiness.CreateStudentAsync(estudante);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = estudante.Id }, estudante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentAsync(int id, Students estudante)
        {
            if (id != estudante.Id)
            {
                return BadRequest("ID do estudante não corresponde.");
            }

            try
            {
                await _studentsbusiness.UpdateStudentAsync(estudante);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            try
            {
                await _studentsbusiness.DeleteStudentAsync(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
