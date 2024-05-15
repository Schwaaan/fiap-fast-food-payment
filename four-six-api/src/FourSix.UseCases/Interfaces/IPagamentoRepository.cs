using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.UseCases.Interfaces
{
    public interface IPagamentoRepository : IGetRepository<Pagamento>, ISetRepository<Pagamento>
    {
        ICollection<Pagamento> ObterPagamentosPorPedido(Guid pedidoId);
    }
}

