using MiniTMS.Dominio.Cliente;

namespace MiniTMS.API.Interfaces
{
    public interface ICliente
    {
        List<ReadClienteDto> BuscarLista();

        ReadClienteDto BuscarPorId(int id);

        CreateClienteDto Adicionar(CreateClienteDto cliente);

        Clientes Editar(UpdateClienteDto clienteDto);

        bool Excluir(int id);
    }
}
