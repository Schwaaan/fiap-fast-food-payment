using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Infrastructure.DataAccess.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(Context context) : base(context)
        {
        }
    }
}
