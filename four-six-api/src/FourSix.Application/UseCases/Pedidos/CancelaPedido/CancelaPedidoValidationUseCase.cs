using FourSix.Application.Services;
using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Application.UseCases.Pedidos.CancelaPedido
{
    public class CancelaPedidoValidationUseCase : ICancelaPedidoUseCase
    {
        private readonly Notification _notification;
        private readonly ICancelaPedidoUseCase _useCase;
        private IOutputPort<Pedido> _outputPort;

        public CancelaPedidoValidationUseCase(ICancelaPedidoUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new CancelaPedidoPresenter();
        }

        public void SetOutputPort(IOutputPort<Pedido> outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        public async Task Execute(Guid pedidoId, DateTime dataCancelamento)
        {
            if (this._notification
            .IsInvalid)
            {
                this._outputPort
                    .Invalid();
                return;
            }

            await this._useCase
                .Execute(pedidoId, dataCancelamento)
                .ConfigureAwait(false);
        }
    }
}
