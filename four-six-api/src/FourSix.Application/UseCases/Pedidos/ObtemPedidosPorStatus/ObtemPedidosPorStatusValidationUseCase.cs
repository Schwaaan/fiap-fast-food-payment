using FourSix.Application.Services;
using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Application.UseCases.Pedidos.ObtemPedidosPorStatus
{
    public class ObtemPedidosPorStatusValidationUseCase : IObtemPedidosPorStatusUseCase
    {
        private readonly Notification _notification;
        private readonly IObtemPedidosPorStatusUseCase _useCase;
        private IOutputPort<ICollection<Pedido>> _outputPort;

        public ObtemPedidosPorStatusValidationUseCase(IObtemPedidosPorStatusUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new ObtemPedidosPorStatusPresenter();
        }

        public void SetOutputPort(IOutputPort<ICollection<Pedido>> outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        public async Task<ICollection<Pedido>> Execute(EnumStatusPedido statusId)
        {
            if (this._notification
                .IsInvalid)
            {
                this._outputPort.Invalid();
                return null;
            }

            return await this._useCase
                .Execute(statusId)
                .ConfigureAwait(false);
        }
    }
}
