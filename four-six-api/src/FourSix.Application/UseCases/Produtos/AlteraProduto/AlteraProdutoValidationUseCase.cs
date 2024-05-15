using FourSix.Application.Services;
using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.AlteraProduto
{
    public class AlteraProdutoValidationUseCase : IAlteraProdutoUseCase
    {
        private readonly Notification _notification;
        private readonly IAlteraProdutoUseCase _useCase;
        private IOutputPort _outputPort;

        public AlteraProdutoValidationUseCase(IAlteraProdutoUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new AlteraProdutoPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        public async Task Execute(Guid produtoId, string nome, string descricao, EnumCategoriaProduto categoria, decimal preco)
        {
            if (string.IsNullOrEmpty(nome))
                this._notification
                    .Add(nameof(nome), $"{nameof(nome)} é obrigatório.");

            if (string.IsNullOrEmpty(descricao))
                this._notification
                    .Add(nameof(descricao), $"{nameof(descricao)} é obrigatório.");

            if (preco == 0)
                this._notification
                    .Add(nameof(preco), $"{nameof(preco)} é obrigatório.");

            if (this._notification
            .IsInvalid)
            {
                this._outputPort
                    .Invalid();
                return;
            }

            await this._useCase
                .Execute(produtoId, nome, descricao, categoria, preco)
                .ConfigureAwait(false);
        }
    }
}
