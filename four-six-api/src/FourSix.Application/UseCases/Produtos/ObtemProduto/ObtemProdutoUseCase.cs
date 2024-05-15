using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.ObtemProduto
{
    public class ObtemProdutoUseCase : IObtemProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private IOutputPort _outputPort;

        public ObtemProdutoUseCase(IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;
            this._outputPort = new ObtemProdutoPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        public Task Execute(Guid id) =>
            this.ObtemProduto(id);

        private async Task ObtemProduto(Guid id)
        {
            var produto = this._produtoRepository
                  .Listar().Where(x => x.Id == id).FirstOrDefault();

            if (produto != null)
            {
                this._outputPort.Ok(produto);
                return;
            }

            this._outputPort.NotFound();
        }
    }
}