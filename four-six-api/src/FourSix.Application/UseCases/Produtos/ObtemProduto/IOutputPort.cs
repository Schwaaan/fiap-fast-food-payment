using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.ObtemProduto
{
    public interface IOutputPort
    {
        void Invalid();
        void NotFound();
        void Ok(Produto produto);
    }
}
