using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.UseCases.UseCases.Pedidos.ObtemStatusPagamentoPedido
{
    public interface IObtemStatusPagamentoPedidoUseCase
    {
        Task<StatusPagamento> Execute(Guid pedidoId);
    }
}
