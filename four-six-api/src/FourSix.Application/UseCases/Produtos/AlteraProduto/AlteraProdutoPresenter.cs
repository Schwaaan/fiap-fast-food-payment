
using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.AlteraProduto
{
    public sealed class AlteraProdutoPresenter : IOutputPort
    {
        public Produto? Produto { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public bool ExistOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Exist() => this.ExistOutput = true;
        public void Ok(Produto produto) => this.Produto = produto;
    }
}
