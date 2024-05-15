using FourSix.Application.Services;
using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Application.UseCases.Pedidos.AlteraStatusPedido
{
    public class AlteraStatusPedidoValidationUseCase : IAlteraStatusPedidoUseCase
    {
        private readonly Notification _notification;
        private readonly IAlteraStatusPedidoUseCase _useCase;
        private IOutputPort<Pedido> _outputPort;

        public AlteraStatusPedidoValidationUseCase(IAlteraStatusPedidoUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new AlteraStatusPedidoPresenter();
        }

        public void SetOutputPort(IOutputPort<Pedido> outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        public async Task Execute(Guid pedidoId, EnumStatusPedido statusId, DateTime dataStatus)
        {
            if (this._notification
            .IsInvalid)
            {
                this._outputPort
                    .Invalid();
                return;
            }

            await this._useCase
                .Execute(pedidoId, statusId, dataStatus)
                .ConfigureAwait(false);
        }
    }
}
