using FourSix.Domain.Entities.PedidoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourSix.Infrastructure.DataAccess.Configurations
{
    public class PedidoCheckoutConfiguration : IEntityTypeConfiguration<PedidoCheckout>
    {

        public void Configure(EntityTypeBuilder<PedidoCheckout> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("PedidoCheckout");
            builder.HasKey(e => new { e.PedidoId, e.Sequencia });

            builder.Property(b => b.PedidoId)
                .IsRequired()
                .ValueGeneratedNever()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.Sequencia)
                .IsRequired()
                .ValueGeneratedNever()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.StatusId)
                .IsRequired()
                .HasConversion<short>()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.DataStatus)
                .IsRequired()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.HasOne(x => x.Status).WithMany().HasForeignKey(b => b.StatusId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
