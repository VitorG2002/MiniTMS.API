using MiniTMS.Dados.Contextos;
using MiniTMS.Dominio._Base;

namespace MiniTMS.Dados.Repositorios
{
    public class RepositorioBase<TEntity> : IRepositorio<TEntity> where TEntity : Entity
    {
        protected readonly AppDbContext _context;


        public RepositorioBase(AppDbContext context)
        {
            _context = context;
        }


        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public virtual TEntity? Get(int id)
        {
            var query = _context.Set<TEntity>().Where(entity => entity.Id == id);
            return query.Any() ? query.First() : null;
        }

        public virtual List<TEntity> GetAll()
        {
            var entitys = _context.Set<TEntity>().ToList();
            return entitys.Any() ? entitys : new List<TEntity>();
        }
    }
}
