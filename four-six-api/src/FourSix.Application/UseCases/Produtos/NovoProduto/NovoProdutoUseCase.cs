using FourSix.Application.Services;
using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.NovoProduto
{
    public class NovoProdutoUseCase : INovoProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort _outputPort;

        public NovoProdutoUseCase(
            IProdutoRepository produtoRepository,
            IUnitOfWork unitOfWork)
        {
            this._produtoRepository = produtoRepository;
            this._unitOfWork = unitOfWork;
            this._outputPort = new NovoProdutoPresenter();
        }


        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        public Task Execute(string nome, string descricao, EnumCategoriaProduto categoria, decimal preco) =>
            this.NovoProduto(new Produto(Guid.NewGuid(),
                nome,
                descricao,
                categoria,
                preco,
                true));

        private async Task NovoProduto(Produto produto)
        {
            if (this._produtoRepository
                .Listar(q => q.Nome == produto.Nome 
                && q.Categoria == produto.Categoria).Any())
            {
                this._outputPort.Exist();
                return;
            }

            await this._produtoRepository
                 .Incluir(produto)
                 .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);

            this._outputPort?.Ok(produto);

        }
    }
}
