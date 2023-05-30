using MiniTMS.Dominio.Status;

namespace MiniTMS.API.Interfaces
{
    public interface IStatus
    {
        List<ReadStatusDto> BuscarLista();

        ReadStatusDto BuscarPorId(int id);

        CreateStatusDto Adicionar(CreateStatusDto status);

        Statuses Editar(UpdateStatusDto status);

        bool Excluir(int id);
    }
}
