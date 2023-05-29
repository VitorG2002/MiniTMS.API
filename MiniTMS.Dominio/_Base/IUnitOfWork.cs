namespace MiniTMS.Dominio._Base
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
