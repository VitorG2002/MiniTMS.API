using Microsoft.EntityFrameworkCore;
using MiniTMS.Dados.Contextos;
using MiniTMS.Dominio.Cliente;

namespace MiniTMS.Dados.Repositorios
{
    public  class ClienteRepositorio : RepositorioBase<Clientes>, IClienteRepositorio
    {
        public ClienteRepositorio(AppDbContext context) : base(context)
        {
        }

        public List<Clientes> BuscarListaPorIdComEndereco()
        {
            var entitys = _context.Set<Clientes>().Include(entity => entity.Endereco).ToList();
            _context.SaveChanges();
            return entitys.Any() ? entitys : new List<Clientes>();
        }

        public Clientes? BuscarPorIdComEndereco(int id)
        {

            var query = _context.Set<Clientes>().Where(entity => entity.Id == id).Include(entity => entity.Endereco);
            _context.SaveChanges();
            return query.Any() ? query.First() : null;
        }

    }
}
