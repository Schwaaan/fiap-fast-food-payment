using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Infrastructure.DataAccess.Repositories
{
    public class PedidoStatusRepository : BaseRepository<PedidoCheckout, EnumStatusPedido>, IPedidoCheckoutRepository
    {
        public PedidoStatusRepository(Context context) : base(context)
        {
        }
    }
}
