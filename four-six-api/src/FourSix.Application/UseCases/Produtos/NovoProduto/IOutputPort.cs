using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.NovoProduto
{
    public interface IOutputPort
    {
        void Invalid();
        void NotFound();
        void Ok(Produto produto);
        void Exist();
    }
}
