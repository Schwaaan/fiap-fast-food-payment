namespace FourSix.UseCases.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}
