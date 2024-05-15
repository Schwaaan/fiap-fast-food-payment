using System.Linq.Expressions;

namespace FourSix.UseCases.Interfaces
{
    public interface IGetRepository<T, C> where T : class
    {
        //IQueryable<T> Listar();
        T Obter(C id);
        IEnumerable<T> Listar(Expression<Func<T, bool>>? predicate = null);
    }

    public interface IGetRepository<T>: IGetRepository<T, Guid> where T : class
    {
    }
}
