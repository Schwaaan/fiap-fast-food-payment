namespace FourSix.Application.UseCases
{
    public interface IOutputPort<T>
    {
        void Ok(T entidade);
        void NotFound();
        void Invalid();
        void Exist();
    }
}
