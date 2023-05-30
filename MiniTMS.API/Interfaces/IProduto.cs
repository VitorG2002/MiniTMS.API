using MiniTMS.Dominio.Produto;

namespace MiniTMS.API.Interfaces
{
    public interface IProduto
    {
        List<ReadProdutoDto> BuscarLista();

        ReadProdutoDto BuscarPorId(int id);

        CreateProdutoDto Adicionar(CreateProdutoDto status);

        Produtos Editar(UpdateProdutoDto status);

        bool Excluir(int id);
    }
}
