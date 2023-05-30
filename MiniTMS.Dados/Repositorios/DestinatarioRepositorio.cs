using Microsoft.EntityFrameworkCore;
using MiniTMS.Dados.Contextos;
using MiniTMS.Dominio.Destinatario;

namespace MiniTMS.Dados.Repositorios
{
    public class DestinatarioRepositorio : RepositorioBase<Destinatarios>, IDestinatarioRepositorio
    {
        public DestinatarioRepositorio(AppDbContext context) : base(context)
        {
        }

        public List<Destinatarios> BuscarListaPorIdComEndereco()
        {
            var entitys = _context.Set<Destinatarios>().Include(entity => entity.Endereco).ToList();
            _context.SaveChanges();
            return entitys.Any() ? entitys : new List<Destinatarios>();
        }

        public Destinatarios? BuscarPorIdComEndereco(int id)
        {

            var query = _context.Set<Destinatarios>().Where(entity => entity.Id == id).Include(entity => entity.Endereco);
            _context.SaveChanges();
            return query.Any() ? query.First() : null;
        }

    }
}
