using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.UseCases.UseCases.Pagamentos.ObtemStatusPagamentoPedido
{
    public interface IObtemStatusPagamentoPedidoUseCase
    {
        Task<StatusPagamento> Execute(Guid pedidoId);
    }
}
