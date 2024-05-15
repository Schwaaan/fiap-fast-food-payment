

namespace FourSix.Application.UseCases.Produtos.InativaProduto
{
    public sealed class InativaProdutoPresenter : IOutputPort
    {
        public bool OkOutput { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public bool ExistPedidoOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void ExistPedido() => this.ExistPedidoOutput = true;
        public void Ok() => this.OkOutput = true;
    }
}
