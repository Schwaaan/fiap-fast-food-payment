using FourSix.Application.Services;
using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.AlteraProduto
{
    public class AlteraProdutoUseCase : IAlteraProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort _outputPort;

        public AlteraProdutoUseCase(
            IProdutoRepository produtoRepository,
            IUnitOfWork unitOfWork)
        {
            this._produtoRepository = produtoRepository;
            this._unitOfWork = unitOfWork;
            this._outputPort = new AlteraProdutoPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(Guid produtoId, string nome, string descricao, EnumCategoriaProduto categoria, decimal preco) =>
            this.AlteraProduto(
                new Produto(produtoId,
                    nome,
                    descricao,
                    categoria,
                    preco,
                    true));

        private async Task AlteraProduto(Produto produto)
        {

            if (this._produtoRepository
                .Listar(q => q.Nome == produto.Nome
                && q.Categoria == produto.Categoria).Any())
            {
                this._outputPort.Exist();
                return;
            }

            await this._produtoRepository
                 .Alterar(produto)
                 .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);

            this._outputPort?.Ok(produto);

        }
    }
}
