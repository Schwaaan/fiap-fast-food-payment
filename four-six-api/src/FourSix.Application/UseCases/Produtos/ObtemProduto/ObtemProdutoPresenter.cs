using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.ObtemProduto
{
    public class ObtemProdutoPresenter : IOutputPort
    {
        public Produto Produto { get; private set; }
        public bool? IsNotFound { get; private set; }
        public bool? InvalidOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.IsNotFound = true;
        public void Ok(Produto produto) => this.Produto = produto;

    }
}
