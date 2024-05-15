using FourSix.Application.Services;

namespace FourSix.Application.UseCases.Produtos.ObtemProduto
{
    public class ObtemProdutoValidationUseCase : IObtemProdutoUseCase
    {
        private readonly Notification _notification;
        private readonly IObtemProdutoUseCase _useCase;
        private IOutputPort _outputPort;

        public ObtemProdutoValidationUseCase(IObtemProdutoUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new ObtemProdutoPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        public async Task Execute(Guid id)
        {
            await this._useCase
                .Execute(id)
                .ConfigureAwait(false);
        }
    }
}
