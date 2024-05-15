using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Infrastructure.DataAccess.Repositories
{
    public class PedidoItemRepository : BaseRepository<PedidoItem, Guid>, IPedidoItemRepository
    {
        public PedidoItemRepository(Context context) : base(context)
        {
        }
    }
}
