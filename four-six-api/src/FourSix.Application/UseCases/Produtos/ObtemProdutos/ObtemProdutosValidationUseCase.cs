using FourSix.Application.Services;

namespace FourSix.Application.UseCases.Produtos.ObtemProdutos
{
    public class ObtemProdutosValidationUseCase : IObtemProdutosUseCase
    {
        private readonly Notification _notification;
        private readonly IObtemProdutosUseCase _useCase;
        private IOutputPort _outputPort;

        public ObtemProdutosValidationUseCase(IObtemProdutosUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new ObtemProdutosPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        public async Task Execute()
        {
            await this._useCase
                .Execute()
                .ConfigureAwait(false);
        }
    }
}
