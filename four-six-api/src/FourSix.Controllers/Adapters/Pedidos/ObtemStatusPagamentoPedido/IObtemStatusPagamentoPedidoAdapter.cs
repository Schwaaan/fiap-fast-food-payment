namespace FourSix.Controllers.Adapters.Pedidos.ObtemStatusPagamentoPedido
{
    public interface IObtemStatusPagamentoPedidoAdapter
    {
        Task<ObtemStatusPagamentoPedidoResponse> ObterStatusPagamento(Guid pedidoId);
    }
}
