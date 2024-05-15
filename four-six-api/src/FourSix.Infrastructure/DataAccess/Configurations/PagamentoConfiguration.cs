using FourSix.Domain.Entities.PagamentoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourSix.Infrastructure.DataAccess.Configurations
{
    public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Pagamento");
            builder.HasKey(e => e.Id);

            builder.Property(b => b.Id).IsRequired()
                .ValueGeneratedOnAdd()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.PedidoId)
                .IsRequired()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.CodigoQR)
                .IsRequired()
                .HasMaxLength(500)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.StatusId)
                .IsRequired()
                .HasConversion<short>()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.ValorPedido)
                .IsRequired()
                .HasPrecision(18,2)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.Desconto)
                .IsRequired()
                .HasPrecision(18, 2)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.ValorTotal)
                .IsRequired()
                .HasPrecision(18, 2)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.ValorPago)
                .IsRequired()
                .HasPrecision(18, 2)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.HasOne(x => x.Pedido).WithMany().HasForeignKey(b => b.PedidoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Status).WithMany().HasForeignKey(b => b.StatusId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
