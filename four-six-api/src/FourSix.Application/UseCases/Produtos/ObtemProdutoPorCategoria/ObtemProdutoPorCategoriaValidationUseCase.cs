using FourSix.Application.Services;
using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.ObtemProdutoPorCategoria
{
    // entender onde isso é usado.
    public class ObtemProdutoPorCategoriaValidationUseCase : IObtemProdutoPorCategoriaUseCase
    {
        private readonly Notification _notification;
        private readonly IObtemProdutoPorCategoriaUseCase _useCase;
        private IOutputPort _outputPort;

        public ObtemProdutoPorCategoriaValidationUseCase(IObtemProdutoPorCategoriaUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new ObtemProdutoPorCategoriaPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        public async Task Execute(EnumCategoriaProduto categoria)
        {
            await this._useCase
                .Execute(categoria)
                .ConfigureAwait(false);
        }
    }
}
