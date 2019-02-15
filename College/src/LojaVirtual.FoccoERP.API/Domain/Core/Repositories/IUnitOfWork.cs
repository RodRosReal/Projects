namespace Domain.Core
{
    public interface IUnitOfWork
    {
        void Commit();

        void Rollback();
    }
}
