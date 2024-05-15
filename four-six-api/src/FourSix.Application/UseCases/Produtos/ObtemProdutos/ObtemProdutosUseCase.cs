using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.ObtemProdutos
{
    public class ObtemProdutosUseCase : IObtemProdutosUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private IOutputPort _outputPort;

        public ObtemProdutosUseCase(IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;
            this._outputPort = new ObtemProdutosPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        public Task Execute() =>
            this.ObtemProdutos();

        private async Task ObtemProdutos()
        {
            var produtos = this._produtoRepository
                .Listar()
                .Where(q=>q.Ativo).ToList();

            if (produtos != null)
            {
                this._outputPort.Ok(produtos);
                return;
            }

            this._outputPort.NotFound();
        }
    }
}