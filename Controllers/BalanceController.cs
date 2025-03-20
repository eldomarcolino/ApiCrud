using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeRecarga.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceBusiness _balanceBusiness;

        public BalanceController(IBalanceBusiness balanceBusiness)
        {
            _balanceBusiness = balanceBusiness;
        }

        [HttpGet("usuario/{iduser}")]
        public async Task<IActionResult> GetBalanceByIdUserAsync(int idUser)
        {
            try
            {
                var saldo = await _balanceBusiness.GetBalanceByIdUserAsync(idUser);
                return Ok(saldo);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false, Message = ex.Message
                });
            }
        }


        [HttpGet("recarregar")]
        public async Task<IActionResult> AddBalanceAsync([FromBody] int idUser, decimal valor)
        {
            try
            {
                var balance = await _balanceBusiness.AddBalanceAsync(idUser, valor);

                var successResponse = new
                {
                    Success = true,
                    Message = "Recarga realizada com sucesso.",
                    Balance = balance
                };

                return StatusCode(StatusCodes.Status201Created, successResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }  
        

    }
}
