using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FourSix.Controllers.Gateways.Repositories
{
    public class PagamentoRepository : BaseRepository<Pagamento>, IPagamentoRepository
    {
        public PagamentoRepository(DbContext context) : base(context)
        {
        }

        public ICollection<Pagamento> ObterPagamentosPorPedido(Guid pedidoId)
        {
            return _context.Set<Pagamento>().Include(i => i.Status).Where(p => p.PedidoId == pedidoId).ToList();
        }
    }
}
