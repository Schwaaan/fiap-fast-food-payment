using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.UseCases.Interfaces
{
    public interface IOrderIntegrationService
    {
        Task AtualizarPedido(Guid pedidoId, EnumStatusPagamento statusPagamento);
    }
}
