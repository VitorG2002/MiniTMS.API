using MiniTMS.Dominio._Base;

namespace MiniTMS.Dominio.Cliente
{
    public interface IClienteRepositorio : IRepositorio<Clientes>
    {
        List<Clientes> BuscarListaPorIdComEndereco();
        Clientes BuscarPorIdComEndereco(int id);
    }
}
