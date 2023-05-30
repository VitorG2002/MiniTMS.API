using Microsoft.AspNetCore.Mvc;
using MiniTMS.API.Interfaces;
using MiniTMS.API._Util;
using MiniTMS.Dominio.Entregador;

namespace MiniTMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregadorController : ControllerBase
    {

        private readonly IEntregador _services;

        public EntregadorController(IEntregador services)
        {
            _services = services;
        }

        ///<summary>Buscas todos entregadores e seu endereços</summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReadEntregadorDto>))]
        public IActionResult BuscarListaDeEntregadores()
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

        ///<summary>Busca um entregadores específico e seu endereço, usando o id do entregador</summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadEntregadorDto))]
        public IActionResult BuscarEntregadorPorId(int id)
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

        ///<summary>Adiciona um entregador e seu endereço</summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult AdicionarEntregador(CreateEntregadorDto entregador)
        {
            try
            {
                if (!Util.ValidarCPF(entregador.Cpf))
                    return BadRequest("Cpf ou Rg inválidos!");

                var result = _services.Adicionar(entregador);
                if (result != null)
                    return Created("", result);

                return UnprocessableEntity(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && (ex.InnerException.Message.Contains("ix_entregadores_cpf") || ex.InnerException.Message.Contains("ix_entregadores_rg")))
                {
                    return StatusCode(500, "Já existe um entregador com o cpf ou rg digitados!");
                }
                return StatusCode(500, ex.Message);
            }
        }


        ///<summary>Edita um entregador e seu endereço</summary>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult EditarEntregador(UpdateEntregadorDto entregador)
        {
            try
            {
                if (entregador == null || entregador.Id == 0)
                    return BadRequest("Id inválido!");

                if (!Util.ValidarCPF(entregador.Cpf))
                    return BadRequest("Cpf ou Rg inválidos!");

                var result = _services.Editar(entregador);
                if (result != null)
                    return NoContent();

                return Conflict(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && (ex.InnerException.Message.Contains("ix_entregadores_cpf") || ex.InnerException.Message.Contains("ix_entregadores_rg")))
                {
                    return StatusCode(500, "Já existe um entregador com o cpf ou rg digitados!");
                }
                return StatusCode(500, ex.Message);
            }
        }


        ///<summary>Deleta um entregador e seu endereço</summary>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ExcluirEntregador(int id)
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
