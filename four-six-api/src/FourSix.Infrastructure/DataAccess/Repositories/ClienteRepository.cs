using FourSix.Domain.Entities;
using FourSix.Domain.Entities.ClienteAggregate;

namespace FourSix.Infrastructure.DataAccess.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(Context context) : base(context)
        {
        }
    }
}
