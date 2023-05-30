using Microsoft.AspNetCore.Mvc;
using MiniTMS.API.Interfaces;
using MiniTMS.Dominio.Produto;

namespace MiniTMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController :ControllerBase
    {
        private readonly IProduto _services;
        public ProdutoController(IProduto services)
        {
                _services = services;
        }

        ///<summary>Buscas todos os produtos</summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReadProdutoDto>))]
        public IActionResult BuscarListaDeProduto()
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

        ///<summary>Busca um produto específico, usando o id do produto</summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadProdutoDto))]
        public IActionResult BuscarProdutoPorId(int id)
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

        ///<summary>Adiciona um produto</summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult AdicionarProduto(CreateProdutoDto produto)
        {
            try
            {
                var result = _services.Adicionar(produto);
                if (result != null)
                    return Created("", result);

                return UnprocessableEntity(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return StatusCode(500, ex.InnerException.Message);
                }
                return StatusCode(500, ex.Message);
            }
        }


        ///<summary>Edita um produto</summary>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult EditarProduto(UpdateProdutoDto produto)
        {
            try
            {
                if (produto == null || produto.Id == 0)
                    return BadRequest("Id inválido!");

                var result = _services.Editar(produto);
                if (result != null)
                    return NoContent();

                return Conflict(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        ///<summary>Deleta um produto</summary>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ExcluirProduto(int id)
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
