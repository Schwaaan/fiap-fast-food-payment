using FourSix.Domain.Entities.PedidoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourSix.Infrastructure.DataAccess.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {

        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("PedidoItem");
            builder.HasKey(e => new { e.PedidoId, e.ItemPedidoId });
            builder.Property(b => b.PedidoId)
                .IsRequired()
                .ValueGeneratedNever()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.ItemPedidoId)
                .IsRequired()
                .ValueGeneratedNever()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.ValorUnitario)
                .IsRequired()
                .HasPrecision(6, 2)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.Quantidade)
                .IsRequired()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.Observacao)
                .IsRequired(false)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.HasOne(x => x.ItemPedido).WithMany().HasForeignKey(b => b.ItemPedidoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
