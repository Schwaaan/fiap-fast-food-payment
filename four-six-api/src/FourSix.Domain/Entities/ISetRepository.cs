namespace FourSix.Domain.Entities
{
    public interface ISetRepository<T, C> where T : class
    {
        Task Incluir(T entidade);
        Task Alterar(T entidade);
        Task Excluir(C id);
        Task<int> Salvar();
    }

    public interface ISetRepository<T> : ISetRepository<T, Guid> where T : class
    {
    }
}
