using MiniTMS.Dominio.Cliente;

namespace MiniTMS.API.Interfaces
{
    public interface ICliente
    {
        List<ReadClienteDto> BuscarLista();

        ReadClienteDto BuscarPorId(int id);

        Clientes Adicionar(CreateClienteDto cliente);
    }
}
