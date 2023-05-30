using Microsoft.AspNetCore.Mvc;
using MiniTMS.API._Util;
using MiniTMS.API.Interfaces;
using MiniTMS.Dominio.Cliente;
using MiniTMS.Dominio.Entregador;

namespace MiniTMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _services;

        public ClienteController(ICliente services)
        {
            _services = services;
        }

        ///<summary>Buscas todos clientes e seu endereços</summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReadClienteDto>))]
        public IActionResult BuscarListaDeClientes()
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

        ///<summary>Busca um cliente específico e seu endereço, usando o id do cliente</summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadClienteDto))]
        public IActionResult BuscarClientePorId(int id)
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

        ///<summary>Adiciona um cliente e seu endereço</summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult AdicionarCliente(CreateClienteDto cliente)
        {
            try
            {
                if (!Util.ValidarCPF(cliente.CnpjCpf) && !Util.ValidarCNPJ(cliente.CnpjCpf))
                    return BadRequest("Campo Cnpj/Cpf Inválido!");

                var result = _services.Adicionar(cliente);
                if (result != null)
                    return Created("", result);

                return UnprocessableEntity(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("ix_clientes_cnpj_cpf"))
                {
                    return StatusCode(500, "Já existe um cliente com esse Cnpj/Cpf!");
                }
                return StatusCode(500, ex.Message);
            }
        }


        ///<summary>Edita um cliente e seu endereço</summary>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult EditarCliente(UpdateClienteDto cliente)
        {
            try
            {
                if (cliente == null || cliente.Id == 0)
                    return BadRequest("Id inválido!");

                var result = _services.Editar(cliente);
                if (result != null)
                    return NoContent();

                return Conflict(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("ix_clientes_cnpj_cpf"))
                {
                    return StatusCode(500, "Já existe um cliente com esse Cnpj/Cpf!");
                }
                return StatusCode(500, ex.Message);
            }
        }


        ///<summary>Deleta um cliente e seu endereço</summary>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ExcluirCliente(int id)
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
