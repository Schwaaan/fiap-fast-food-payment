using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Application.UseCases.Pedidos.ObtemPedidosPorStatus
{
    public class ObtemPedidosPorStatusUseCase : IObtemPedidosPorStatusUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private IOutputPort<ICollection<Pedido>> _outputPort;

        public ObtemPedidosPorStatusUseCase(IPedidoRepository pedidoRepository)
        {
            this._pedidoRepository = pedidoRepository;
            this._outputPort = new ObtemPedidosPorStatusPresenter();
        }

        public void SetOutputPort(IOutputPort<ICollection<Pedido>> outputPort) => this._outputPort = outputPort;

        public Task<ICollection<Pedido>> Execute(EnumStatusPedido statusId) => this.ListarPedidos(statusId);

        private async Task<ICollection<Pedido>> ListarPedidos(EnumStatusPedido statusId)
        {
            var pedidos = this._pedidoRepository.Listar(q => q.StatusId == statusId).ToList();

            if (pedidos != null && pedidos.Any())
            {
                this._outputPort.Ok(pedidos);
                return null;
            }

            this._outputPort.NotFound();

            return pedidos;
        }
    }
}