namespace Sakura.Core.Data
{
    public interface UnitOfWork
    {
        Task<bool> Commit();
    }
}