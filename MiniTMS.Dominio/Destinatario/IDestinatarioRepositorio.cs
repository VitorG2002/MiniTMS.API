using MiniTMS.Dominio._Base;

namespace MiniTMS.Dominio.Destinatario
{
    public interface IDestinatarioRepositorio : IRepositorio<Destinatarios>
    {
        List<Destinatarios> BuscarListaPorIdComEndereco();
        Destinatarios BuscarPorIdComEndereco(int id);
    }
}
