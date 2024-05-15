using FourSix.Application.Services;
using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Application.UseCases.Pedidos.NovoPedido
{
    public class NovoPedidoUseCase : INovoPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoItemRepository _pedidoItemRepository;
        private readonly IPedidoCheckoutRepository _pedidoCheckoutRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort<Pedido> _outputPort;

        public NovoPedidoUseCase(
            IPedidoRepository pedidoRepository,
            IUnitOfWork unitOfWork,
            IPedidoItemRepository pedidoItemRepository,
            IPedidoCheckoutRepository pedidoCheckoutRepository)
        {
            this._pedidoRepository = pedidoRepository;
            this._unitOfWork = unitOfWork;
            this._outputPort = new NovoPedidoPresenter();
            _pedidoItemRepository = pedidoItemRepository;
            _pedidoCheckoutRepository = pedidoCheckoutRepository;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort<Pedido> outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public async Task Execute(DateTime dataPedido, Guid? clienteId, ICollection<Tuple<Guid, decimal, int, string>> itens)
        {
            var id = Guid.NewGuid();

            await this.IncluiPedido(
                new Pedido(id,
                dataPedido,
                clienteId, 
                itens.Select(i => new PedidoItem(id, i.Item1, i.Item2, i.Item3, i.Item4)).ToList(), 
                new List<PedidoCheckout> { new PedidoCheckout(id, 1, EnumStatusPedido.Recebido, DateTime.Now) }));
        }

        private async Task IncluiPedido(Pedido pedido)
        {
            if (this._pedidoRepository
                .Listar(q => q.NumeroPedido == pedido.NumeroPedido).Any())
            {
                this._outputPort.Exist();
                return;
            }

            await this._pedidoRepository
                 .Incluir(pedido)
                 .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);

            this._outputPort?.Ok(pedido);
        }
    }
}
