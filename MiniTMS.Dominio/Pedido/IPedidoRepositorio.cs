using MiniTMS.Dominio._Base;
using MiniTMS.Dominio.Produto;

namespace MiniTMS.Dominio.Pedido
{
    public interface IPedidoRepositorio : IRepositorio<Pedidos>
    {
        List<Pedidos> BuscarListaPorIdComRelacionamentos();
        Pedidos BuscarPorIdComRelacionamentos(int id);

        void AdicionarPedidoComProdutos(Pedidos pedidos, List<Produtos> produtos);

        void EditarPedido(Pedidos pedido);

        List<Produtos> BuscarProdutosRelacionados(List<int> ids);
    }
}
