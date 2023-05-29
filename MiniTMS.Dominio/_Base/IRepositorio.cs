namespace MiniTMS.Dominio._Base
{
    public interface IRepositorio<TEntity>
    {
        TEntity? Get(int id);
        List<TEntity> GetAll();
        void Add(TEntity entity);
    }
}
