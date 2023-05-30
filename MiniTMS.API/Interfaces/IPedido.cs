using MiniTMS.Dominio.Pedido;

namespace MiniTMS.API.Interfaces
{
    public interface IPedido
    {
        List<ReadPedidoDto> BuscarLista();

        ReadPedidoDto BuscarPorId(int id);

        CreatePedidoDto Adicionar(CreatePedidoDto pedido);

        Pedidos Editar(UpdatePedidoDto pedidoDto);

        bool Excluir(int id);
    }
}
