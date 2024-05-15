using FourSix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace FourSix.Controllers.Gateways.Repositories
{
    public class BaseRepository<T, C> where T : class
    {
        internal readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public virtual T Obter(C id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> Listar(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate == null)
                return _context.Set<T>().AsNoTracking();
            else
                return _context.Set<T>().Where(predicate).AsNoTracking();
        }

        public async Task Incluir(T entidade)
        {
            await _context.Set<T>().AddAsync(entidade);
        }

        public virtual async Task Alterar(T entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
        }

        public virtual async Task Excluir(C id)
        {
            var entity = Obter(id);
            //var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry(entity);
            entityEntry.State = EntityState.Deleted;
        }
    }

    public class BaseRepository<T> : BaseRepository<T, Guid> where T : class, IBaseEntity
    {
        public BaseRepository(DbContext context) : base(context)
        {
        }

        public new T Obter(Guid id)
        {
            return _context.Set<T>().FirstOrDefault(f => f.Id == id);
        }
    }
}
