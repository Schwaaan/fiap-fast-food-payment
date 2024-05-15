namespace FourSix.Application.UseCases.Produtos.ObtemProduto
{
    public interface IObtemProdutoUseCase
    {
        Task Execute(Guid id);
        void SetOutputPort(IOutputPort outputPort);
    }
}
