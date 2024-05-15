using FourSix.Application.Services;

namespace FourSix.Application.UseCases.Produtos.InativaProduto
{
    public class InativaProdutoValidationUseCase : IInativaProdutoUseCase
    {
        private readonly Notification _notification;
        private readonly IInativaProdutoUseCase _useCase;
        private IOutputPort _outputPort;

        public InativaProdutoValidationUseCase(IInativaProdutoUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new InativaProdutoPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        public async Task Execute(Guid produtoId)
        {
            await this._useCase
                .Execute(produtoId)
                .ConfigureAwait(false);
        }
    }
}
