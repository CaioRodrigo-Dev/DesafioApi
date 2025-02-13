using DesafioApiDTO.Request;
using DesafioApiService.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DesafioApi.Controllers
{
    public class FuncionarioController : Controller
    {
        #region Fields
        private readonly IFuncionarioService _service;
        #endregion

        #region Constructor
        public FuncionarioController(IFuncionarioService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service), "Service cannot be null");
        }
        #endregion

        #region EndPoints
        [HttpPost("CreateFuncionario")]
        public async Task<IActionResult> CreateFuncionario ([FromBody] CreateFuncionarioRequestDTO request)
        {
            try
            {
                var funcionario = await _service.CreateFuncionario(request);
                return CreatedAtAction(nameof(GetById), new { id = funcionario.Id }, funcionario);
            }
            catch (Exception ex)
            {
                
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var funcionario = await _service.GetById(id);
                return funcionario == null ? NotFound() : Ok(funcionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllFuncionarios()
        {
            try
            {
                var funcionarios = await _service.GetAllFuncionarios();
                return Ok(funcionarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateFuncionario")]
        public async Task<IActionResult> UpdateFuncionario(int id, UpdateFuncionarioRequestDTO request)
        {
            try
            {
                var funcionario = await _service.UpdateFuncionario(id, request);
                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletarFuncionario")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var funcionario = await _service.DeleteById(id);
                if (funcionario)
                {
                    return Ok(new { message = "Funcionario deletado com sucesso." });
                }

                return NotFound(new { message = $"Funcionario com Id {id} nao foi encontrado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Erro ao deletar funcionario: {ex.Message}" });
            }
        }


        #endregion
    }
}
