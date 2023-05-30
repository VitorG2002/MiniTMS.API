using Microsoft.AspNetCore.Mvc;
using MiniTMS.API.Interfaces;
using MiniTMS.Dominio.Status;

namespace MiniTMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatus _services;

        public StatusController(IStatus services)
        {
            _services = services;
        }

        ///<summary>Busca todos status</summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReadStatusDto>))]
        public IActionResult BuscarListaDeStatus()
        {
            try
            {
                var result = _services.BuscarLista();
                if (result != null)
                    return Ok(result);

                return NotFound("Nenhum registro encontrado!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        ///<summary>Busca um status específico, usando o id do status</summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadStatusDto))]
        public IActionResult BuscarStatusPorId(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest("Id Inválido!");

                var result = _services.BuscarPorId(id);
                if (result != null)
                    return Ok(result);

                return NotFound("Nenhum registro encontrado!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        ///<summary>Adiciona um status</summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult AdicionarStatus(CreateStatusDto status)
        {
            try
            {
                var result = _services.Adicionar(status);
                if (result != null)
                    return Created("", result);

                return UnprocessableEntity(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("ix_status_nome"))
                {
                    return StatusCode(500, "Já existe um status com esse nome, use outro nome ou delete o status existente!");
                }
                return StatusCode(500, ex.Message);
            }
        }


        ///<summary>Edita um status</summary>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult EditarStatus(UpdateStatusDto status)
        {
            try
            {
                if (status == null || status.Id == 0)
                    return BadRequest("Id inválido!");

                var result = _services.Editar(status);
                if (result != null)
                    return NoContent();

                return Conflict(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        ///<summary>Deleta um status</summary>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ExcluirStatus(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest("Id Inválido!");

                var result = _services.Excluir(id);
                if (result)
                    return NoContent();

                return NotFound("Nenhum registro encontrado!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
