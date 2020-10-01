namespace LeilaoOnline.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void BeginTransaction();
    }
}
