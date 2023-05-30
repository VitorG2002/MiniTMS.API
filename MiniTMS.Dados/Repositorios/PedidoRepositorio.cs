using Microsoft.EntityFrameworkCore;
using MiniTMS.Dados.Contextos;
using MiniTMS.Dominio.Pedido;
using MiniTMS.Dominio.Produto;

namespace MiniTMS.Dados.Repositorios
{
    public class PedidoRepositorio : RepositorioBase<Pedidos>, IPedidoRepositorio
    {
        public PedidoRepositorio(AppDbContext context) : base(context)
        {
        }

        public List<Pedidos> BuscarListaPorIdComRelacionamentos()
        {
            var entitys = _context.Set<Pedidos>()
                .Include(entity => entity.Cliente)
                .Include(entity => entity.Destinatario)
                .Include(entity => entity.Entregador)
                .Include(entity => entity.Cliente.Endereco)
                .Include(entity => entity.Destinatario.Endereco)
                .Include(entity => entity.Entregador.Endereco)
                .Include(entity => entity.Status)
                .Include(entity => entity.Produtos).ToList();
            _context.SaveChanges();
            return entitys.Any() ? entitys : new List<Pedidos>();
        }

        public Pedidos? BuscarPorIdComRelacionamentos(int id)
        {

            var query = _context.Set<Pedidos>().Where(entity => entity.Id == id)
                .Include(entity => entity.Cliente)
                .Include(entity => entity.Destinatario)
                .Include(entity => entity.Entregador)
                .Include(entity => entity.Cliente.Endereco)
                .Include(entity => entity.Destinatario.Endereco)
                .Include(entity => entity.Entregador.Endereco)
                .Include(entity => entity.Status)
                .Include(entity => entity.Produtos);
            _context.SaveChanges();
            return query.Any() ? query.First() : null;
        }

        public void AdicionarPedidoComProdutos(Pedidos pedidos, List<Produtos> produtos)
        {
            pedidos.Produtos = produtos;
            Add(pedidos);
            _context.SaveChanges();
        }

        public List<Produtos> BuscarProdutosRelacionados(List<int> ids)
        {
            List<Produtos> produtos = _context.Set<Produtos>().Where(p => ids.Contains(p.Id)).ToList();
            return produtos;
        }
    }
}
