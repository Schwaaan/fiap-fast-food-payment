using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.ObtemProdutoPorCategoria
{
    public interface IObtemProdutoPorCategoriaUseCase
    {
        Task Execute(EnumCategoriaProduto categoria);
        void SetOutputPort(IOutputPort outputPort);
    }
}
