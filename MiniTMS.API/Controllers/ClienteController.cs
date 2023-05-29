using Microsoft.AspNetCore.Mvc;
using MiniTMS.API.Interfaces;
using MiniTMS.Dominio.Cliente;

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

        [HttpGet]
        public IActionResult BuscarListaDeClientes()
        {
            var result = _services.BuscarLista();
            if (result != null)
                return Ok(result);

            return BadRequest();    
        }

        [HttpGet("{id}")]
        public IActionResult BuscarClientePorId(int id)
        {
            var result = _services.BuscarPorId(id);
            if (result != null)
                return Ok(result);

            return BadRequest();
        }

        [HttpPost]
        public IActionResult AdicionarCliente(CreateClienteDto cliente)
        {

            var result = _services.Adicionar(cliente);
            if (result != null)
                return Ok();

            return UnprocessableEntity(result);
        }
    }
}
