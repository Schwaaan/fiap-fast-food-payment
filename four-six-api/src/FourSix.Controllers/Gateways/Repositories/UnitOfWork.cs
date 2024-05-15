using FourSix.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FourSix.Controllers.Gateways.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;
        private bool _disposed;

        public UnitOfWork(DbContext context) => _context = context;

        /// <inheritdoc />
        public void Dispose() => Dispose(true);

        /// <inheritdoc />
        public async Task<int> Save()
        {
            int affectedRows = await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);
            return affectedRows;
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }
    }
}
