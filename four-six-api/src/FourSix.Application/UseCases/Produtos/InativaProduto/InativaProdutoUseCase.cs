using FourSix.Application.Services;
using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.InativaProduto
{
    public class InativaProdutoUseCase : IInativaProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort _outputPort;

        public InativaProdutoUseCase(
            IProdutoRepository produtoRepository,
            IPedidoRepository pedidoRepository,
            IUnitOfWork unitOfWork)
        {
            this._produtoRepository = produtoRepository;
            this._pedidoRepository = pedidoRepository;
            this._unitOfWork = unitOfWork;
            this._outputPort = new InativaProdutoPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(Guid produtoId) =>
            this.ExcluiProduto(produtoId);

        private async Task ExcluiProduto(Guid produtoId)
        {
            var produto = this._produtoRepository
                .Obter(produtoId);

            if (produto == null)
            {
                this._outputPort?.NotFound();
                return;
            }

            produto.InativarProduto();

            await this._produtoRepository
                 .Alterar(produto)
                 .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);

            this._outputPort?.Ok();

        }
    }
}
