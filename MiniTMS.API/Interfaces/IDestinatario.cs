using MiniTMS.Dominio.Destinatario;

namespace MiniTMS.API.Interfaces
{
    public interface IDestinatario
    {
        List<ReadDestinatarioDto> BuscarLista();
        ReadDestinatarioDto BuscarPorId(int id);
        CreateDestinatarioDto Adicionar(CreateDestinatarioDto destinatarioDto);
        Destinatarios Editar(UpdateDestinatarioDto destinatarioDto);
        public bool Excluir(int id);
    }
}
