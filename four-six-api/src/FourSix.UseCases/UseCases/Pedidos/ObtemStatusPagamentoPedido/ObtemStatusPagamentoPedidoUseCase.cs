using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Pedidos.ObtemStatusPagamentoPedido
{
    public class ObtemStatusPagamentoPedidoUseCase : IObtemStatusPagamentoPedidoUseCase
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public ObtemStatusPagamentoPedidoUseCase(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public Task<StatusPagamento> Execute(Guid pedidoId) => ObterStatusPagamento(pedidoId);

        private async Task<StatusPagamento> ObterStatusPagamento(Guid pedidoId)
        {
            var statusPagamento = _pagamentoRepository.ObterPagamentosPorPedido(pedidoId)
                .OrderByDescending(o => o.DataAtualizacao).Select(s => s.Status).FirstOrDefault();

            if (statusPagamento == null)
            {
                throw new Exception("Pagamento não encontrado");
            }

            return statusPagamento;
        }
    }
}