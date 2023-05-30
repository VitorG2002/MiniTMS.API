using Microsoft.EntityFrameworkCore;
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
            _context.SaveChanges();
        }

        public virtual TEntity? Get(int id)
        {
            var query = _context.Set<TEntity>().Where(entity => entity.Id == id);
            return query.Any() ? query.First() : null;
        }

        public virtual List<TEntity> GetAll()
        {
            var entitys = _context.Set<TEntity>().ToList();
            _context.SaveChanges();
            return entitys.Any() ? entitys : new List<TEntity>();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var rowsDeleted = _context.Set<TEntity>().Where(e => e.Id == id).ExecuteDelete();
            _context.SaveChanges();
            if (rowsDeleted > 0)
                return true;

            return false;
        }
    }
}
