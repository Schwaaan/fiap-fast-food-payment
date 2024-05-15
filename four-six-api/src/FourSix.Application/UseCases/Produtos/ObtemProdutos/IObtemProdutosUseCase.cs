namespace FourSix.Application.UseCases.Produtos.ObtemProdutos
{
    public interface IObtemProdutosUseCase
    {
        Task Execute();
        void SetOutputPort(IOutputPort outputPort);
    }
}
