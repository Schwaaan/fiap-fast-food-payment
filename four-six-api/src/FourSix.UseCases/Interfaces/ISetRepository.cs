namespace FourSix.UseCases.Interfaces
{
    public interface ISetRepository<T, C> where T : class
    {
        Task Incluir(T entidade);
        Task Alterar(T entidade);
        Task Excluir(C id);
    }

    public interface ISetRepository<T> : ISetRepository<T, Guid> where T : class
    {
    }
}
