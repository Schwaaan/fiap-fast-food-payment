using FourSix.Application.Services;
using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Application.UseCases.Pedidos.NovoPedido
{
    public class NovoPedidoValidationUseCase : INovoPedidoUseCase
    {
        private readonly Notification _notification;
        private readonly INovoPedidoUseCase _useCase;
        private IOutputPort<Pedido> _outputPort;

        public NovoPedidoValidationUseCase(INovoPedidoUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new NovoPedidoPresenter();
        }

        public void SetOutputPort(IOutputPort<Pedido> outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        public async Task Execute(DateTime dataPedido, Guid? clienteId, ICollection<Tuple<Guid, decimal, int, string>> itens)
        {
            if (this._notification
            .IsInvalid)
            {
                this._outputPort
                    .Invalid();
                return;
            }

            await this._useCase
                .Execute(dataPedido, clienteId, itens)
                .ConfigureAwait(false);
        }
    }
}
