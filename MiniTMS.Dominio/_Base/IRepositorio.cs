namespace MiniTMS.Dominio._Base
{
    public interface IRepositorio<TEntity>
    {
        TEntity? Get(int id);
        List<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        bool Delete(int id);
    }
}
