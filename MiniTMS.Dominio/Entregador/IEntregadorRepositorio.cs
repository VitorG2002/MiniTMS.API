using MiniTMS.Dominio._Base;

namespace MiniTMS.Dominio.Entregador
{
    public interface IEntregadorRepositorio : IRepositorio<Entregadores>
    {
        List<Entregadores> BuscarListaPorIdComEndereco();
        Entregadores BuscarPorIdComEndereco(int id);
    }
}
