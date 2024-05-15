using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.ObtemProdutoPorCategoria
{
    public interface IOutputPort
    {
        void Invalid();
        void NotFound();
        void Ok(IList<Produto> produtos);
    }
}
