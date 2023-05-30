using MiniTMS.Dominio.Cliente;
using MiniTMS.Dominio.Entregador;

namespace MiniTMS.API.Interfaces
{
    public interface IEntregador
    {
        List<ReadEntregadorDto> BuscarLista();

        ReadEntregadorDto BuscarPorId(int id);

        CreateEntregadorDto Adicionar(CreateEntregadorDto entregadorDto);

        Entregadores Editar(UpdateEntregadorDto entregadorDto);

        bool Excluir(int id);
    }
}
