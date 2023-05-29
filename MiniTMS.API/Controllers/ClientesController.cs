using Microsoft.AspNetCore.Mvc;
using MiniTMS.Dominio._Base;
using MiniTMS.Dominio.Clientes;

namespace MiniTMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IRepositorio<Clientes> _clienteRepositorio;

        public ClientesController(IRepositorio<Clientes> clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpPost("Adicionar")]
        public IActionResult AdicionarCliente(CreateClienteDto cliente)
        {
            //_clienteRepositorio.Add(cliente);
            if (cliente != null)
                return Ok();

            return UnprocessableEntity(cliente);
        }
    }
}
