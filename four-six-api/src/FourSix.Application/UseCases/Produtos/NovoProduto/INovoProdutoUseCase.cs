using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.NovoProduto
{
    public interface INovoProdutoUseCase
    {
        
        Task Execute(string nome, string descricao, EnumCategoriaProduto categoria, decimal preco);

        void SetOutputPort(IOutputPort outputPort);
    }
}
