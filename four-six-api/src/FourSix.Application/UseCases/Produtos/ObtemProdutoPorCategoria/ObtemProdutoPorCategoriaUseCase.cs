using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.ObtemProdutoPorCategoria
{
    public class ObtemProdutoPorCategoriaUseCase : IObtemProdutoPorCategoriaUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private IOutputPort _outputPort;

        public ObtemProdutoPorCategoriaUseCase(IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;
            this._outputPort = new ObtemProdutoPorCategoriaPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        public Task Execute(EnumCategoriaProduto categoria) =>
            this.ObtemProdutoPorCategoria(categoria);

        private async Task ObtemProdutoPorCategoria(EnumCategoriaProduto categoria)
        {
            var produtos = this._produtoRepository
                  .Listar().Where(x => x.Categoria == categoria
                  && x.Ativo).ToList();

            if (produtos != null)
            {
                this._outputPort.Ok(produtos);
                return;
            }

            this._outputPort.NotFound();
        }
    }
}