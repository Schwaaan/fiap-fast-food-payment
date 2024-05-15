using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Infrastructure.DataAccess.Repositories
{
    public class PagamentoRepository : BaseRepository<Pagamento>, IPagamentoRepository
    {
        public PagamentoRepository(Context context) : base(context)
        {
        }
    }
}
