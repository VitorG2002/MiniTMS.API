using Microsoft.AspNetCore.Mvc;
using MiniTMS.API._Util;
using MiniTMS.API.Interfaces;
using MiniTMS.Dominio.Cliente;
using MiniTMS.Dominio.Destinatario;

namespace MiniTMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinatarioController : ControllerBase
    {
        private readonly IDestinatario _services;

        public DestinatarioController(IDestinatario services)
        {
            _services = services;
        }

        ///<summary>Buscas todos destinatários e seu endereços</summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReadDestinatarioDto>))]
        public IActionResult BuscarListaDeDestinatarios()
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

        ///<summary>Busca um destinatário específico e seu endereço, usando o id do destinatario</summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadDestinatarioDto))]
        public IActionResult BuscarDestinatarioPorId(int id)
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

        ///<summary>Adiciona um destinatário e seu endereço</summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult AdicionarDestinatario(CreateDestinatarioDto destinatario)
        {
            try
            {
                if (!Util.ValidarCPF(destinatario.CnpjCpf) && !Util.ValidarCNPJ(destinatario.CnpjCpf))
                    return BadRequest("Campo Cnpj/Cpf Inválido!");

                var result = _services.Adicionar(destinatario);
                if (result != null)
                    return Created("", result);

                return UnprocessableEntity(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("ix_destinatarios_cnpj_cpf"))
                {
                    return StatusCode(500, "Já existe um destinatário com esse Cnpj/Cpf!");
                }
                return StatusCode(500, ex.Message);
            }
        }


        ///<summary>Edita um destinatário e seu endereço</summary>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult EditarDestinatario(UpdateDestinatarioDto destinatario)
        {
            try
            {
                if (destinatario == null || destinatario.Id == 0)
                    return BadRequest("Id inválido!");

                var result = _services.Editar(destinatario);
                if (result != null)
                    return NoContent();

                return Conflict(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("ix_destinatarios_cnpj_cpf"))
                {
                    return StatusCode(500, "Já existe um destinatário com esse Cnpj/Cpf!");
                }
                return StatusCode(500, ex.Message);
            }
        }


        ///<summary>Deleta um destinatário e seu endereço</summary>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ExcluirDestinatario(int id)
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
