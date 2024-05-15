using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.ObtemProdutos
{
    public interface IOutputPort
    {
        void Invalid();
        void NotFound();
        void Ok(IList<Produto> produtos);
    }
}
