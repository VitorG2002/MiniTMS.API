using Microsoft.AspNetCore.Mvc;
using MiniTMS.API.Interfaces;
using MiniTMS.Dominio.Pedido;

namespace MiniTMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedido _services;

        public PedidoController(IPedido services)
        {
            _services = services;
        }

        ///<summary>Buscas todos pedidos e seus relacionamentos</summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReadPedidoDto>))]
        public IActionResult BuscarListaDePedidos()
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
                if (ex.InnerException != null)
                    return StatusCode(500, ex.InnerException.Message);

                return StatusCode(500, ex.Message);
            }
        }

        ///<summary>Busca um pedido específico e seus relacionamentos, usando o id do pedido</summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadPedidoDto))]
        public IActionResult BuscarPedidoPorId(int id)
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

        ///<summary>Adiciona um pedido e seus relacionamentos</summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult AdicionarPedido(CreatePedidoDto pedido)
        {
            try
            {
                var result = _services.Adicionar(pedido);
                if (result != null)
                    return Created("", result);

                return UnprocessableEntity(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message.Contains("fk_pedidos_clientes_clientes_id"))
                    return StatusCode(500, "Id de cliente inexistente!");

                    if (ex.InnerException.Message.Contains("fk_pedidos_destinatarios_destinatarios_id"))
                        return StatusCode(500, "Id de destinatário inexistente!");

                    if (ex.InnerException.Message.Contains("fk_pedidos_entregadores_entregadores_id"))
                        return StatusCode(500, "Id de entregador inexistente!");

                    if (ex.InnerException.Message.Contains("fk_pedidos_status_status_id"))
                        return StatusCode(500, "Id de status inexistente!");
                }
                return StatusCode(500, ex.Message);
            }
        }


        ///<summary>Edita um pedido e seus relacionamentos</summary>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult EditarPedido(UpdatePedidoDto pedido)
        {
            try
            {
                if (pedido == null || pedido.Id == 0)
                    return BadRequest("Id inválido!");

                var result = _services.Editar(pedido);
                if (result != null)
                    return NoContent();

                return Conflict(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message.Contains("fk_pedidos_clientes_clientes_id"))
                        return StatusCode(500, "Id de cliente inexistente!");

                    if (ex.InnerException.Message.Contains("fk_pedidos_destinatarios_destinatarios_id"))
                        return StatusCode(500, "Id de destinatário inexistente!");

                    if (ex.InnerException.Message.Contains("fk_pedidos_entregadores_entregadores_id"))
                        return StatusCode(500, "Id de entregador inexistente!");

                    if (ex.InnerException.Message.Contains("fk_pedidos_status_status_id"))
                        return StatusCode(500, "Id de status inexistente!");
                }
                return StatusCode(500, ex.Message);
            }
        }


        ///<summary>Deleta um pedido e seus relacionamentos</summary>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ExcluirPedido(int id)
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
