using FourSix.Controllers.ViewModels;

namespace FourSix.Controllers.Adapters.Pedidos.ObtemStatusPagamentoPedido
{
    public class ObtemStatusPagamentoPedidoResponse
    {
        public ObtemStatusPagamentoPedidoResponse(StatusPagamentoModel statusPagamento) => StatusPagamento = statusPagamento;
        public StatusPagamentoModel StatusPagamento { get; }
    }
}
