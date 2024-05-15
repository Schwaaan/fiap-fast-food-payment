using FourSix.Application.Services;
using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.NovoProduto
{
    public class NovoProdutoValidationUseCase : INovoProdutoUseCase
    {
        private readonly Notification _notification;
        private readonly INovoProdutoUseCase _useCase;
        private IOutputPort _outputPort;

        public NovoProdutoValidationUseCase(INovoProdutoUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new NovoProdutoPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        public async Task Execute(string nome, string descricao, EnumCategoriaProduto categoria, decimal preco)
        {
            if (string.IsNullOrEmpty(nome))
                this._notification
                    .Add(nameof(nome), $"{nameof(nome)} é obrigatório.");

            if (string.IsNullOrEmpty(descricao))
                this._notification
                    .Add(nameof(descricao), $"{nameof(descricao)} é obrigatório.");


            if (this._notification
            .IsInvalid)
            {
                this._outputPort
                    .Invalid();
                return;
            }

            await this._useCase
                .Execute(nome, descricao, categoria, preco)
                .ConfigureAwait(false);
        }
    }
}