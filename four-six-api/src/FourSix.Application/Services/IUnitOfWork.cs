namespace FourSix.UseCases.Services
{
    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}
