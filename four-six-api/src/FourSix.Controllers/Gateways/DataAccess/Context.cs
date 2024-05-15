using FourSix.Controllers.Gateways.Configurations;
using FourSix.Domain.Entities.PagamentoAggregate;
using Microsoft.EntityFrameworkCore;

namespace FourSix.Controllers.Gateways.DataAccess
{
    public class Context : DbContext
    {
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<StatusPagamento> StatusPagamentos { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

            modelBuilder.ApplyConfiguration(new PagamentoConfiguration());
            modelBuilder.ApplyConfiguration(new StatusPagamentoConfiguration());
            SeedData.Seed(modelBuilder);
        }
    }
}
