using FourSix.Domain.Entities.PagamentoAggregate;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FourSix.Controllers.Gateways.DataAccess
{
    [ExcludeFromCodeCoverage]
    public static class SeedData
    {
        public static void Seed(ModelBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            #region POPULA StatusPagamento

            builder.Entity<StatusPagamento>()
                .HasData(
                 new
                 {
                     Id = EnumStatusPagamento.AguardandoPagamento,
                     Descricao = "Aguardando Pagamento"
                 },
                new
                {
                    Id = EnumStatusPagamento.Pago,
                    Descricao = "Pago"
                },
                new
                {
                    Id = EnumStatusPagamento.Cancelado,
                    Descricao = "Cancelado"
                },
                new
                {
                    Id = EnumStatusPagamento.Negado,
                    Descricao = "Negado"
                });

            #endregion
        }
    }
}
