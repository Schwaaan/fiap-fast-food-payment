using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.ObtemProdutoPorCategoria
{
    public class ObtemProdutoPorCategoriaPresenter : IOutputPort
    {
        public IList<Produto> Produtos { get; private set; }
        public bool? IsNotFound { get; private set; }
        public bool? InvalidOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.IsNotFound = true;

        public void Ok(IList<Produto> produtos) => this.Produtos = produtos;

    }
}
