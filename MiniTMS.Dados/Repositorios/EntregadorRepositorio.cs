using Microsoft.EntityFrameworkCore;
using MiniTMS.Dados.Contextos;
using MiniTMS.Dominio.Entregador;

namespace MiniTMS.Dados.Repositorios
{
    public class EntregadorRepositorio : RepositorioBase<Entregadores>, IEntregadorRepositorio
    {
        public EntregadorRepositorio(AppDbContext context) : base(context)
        {
        }

        public List<Entregadores> BuscarListaPorIdComEndereco()
        {
            var entitys = _context.Set<Entregadores>().Include(entity => entity.Endereco).ToList();
            _context.SaveChanges();
            return entitys.Any() ? entitys : new List<Entregadores>();
        }

        public Entregadores? BuscarPorIdComEndereco(int id)
        {

            var query = _context.Set<Entregadores>().Where(entity => entity.Id == id).Include(entity => entity.Endereco);
            _context.SaveChanges();
            return query.Any() ? query.First() : null;
        }

    }
}
