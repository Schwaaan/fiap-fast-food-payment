using FourSix.Application.Services;
using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Application.UseCases.Pedidos.CancelaPedido
{
    public class CancelaPedidoUseCase : ICancelaPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoCheckoutRepository _pedidoStatusRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort<Pedido> _outputPort;

        public CancelaPedidoUseCase(
            IPedidoRepository pedidoRepository,
            IUnitOfWork unitOfWork,
            IPedidoCheckoutRepository pedidoStatusRepository)
        {
            this._pedidoRepository = pedidoRepository;
            this._unitOfWork = unitOfWork;
            this._outputPort = new CancelaPedidoPresenter();
            _pedidoStatusRepository = pedidoStatusRepository;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort<Pedido> outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public async Task Execute(Guid pedidoId, DateTime dataCancelamento)
        {
            await this.CancelaPedido(pedidoId, dataCancelamento);
        }

        private async Task CancelaPedido(Guid pedidoId, DateTime dataCancelamento)
        {
            var pedido = this._pedidoRepository.Listar(q => q.Id == pedidoId).FirstOrDefault();

            if (pedido == null)
            {
                this._outputPort.NotFound();
                return;
            }

            var novaSequencia = _pedidoStatusRepository.Listar(l => l.PedidoId == pedidoId).Max(l => l.Sequencia) + 1;

            await this._pedidoStatusRepository
                 .Incluir(new PedidoCheckout(pedidoId, novaSequencia, EnumStatusPedido.Cancelado, dataCancelamento))
                 .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);

            this._outputPort?.Ok(pedido);
        }
    }
}
