using FourSix.Domain.Entities.ClienteAggregate;
using FourSix.Domain.Entities.PedidoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourSix.Infrastructure.DataAccess.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {

        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Pedido");
            builder.HasKey(e => e.Id);
            builder.Property(b => b.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.ClienteId)
                .IsRequired(false)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.NumeroPedido)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
                .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            builder.Property(b => b.DataPedido)
                .IsRequired()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.StatusId)
                .IsRequired()
                .HasConversion<short>()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.HasOne(x => x.Cliente).WithMany().HasForeignKey(b => b.ClienteId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Status).WithMany().HasForeignKey(b => b.StatusId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Itens).WithOne().HasForeignKey(b => b.PedidoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.HistoricoCheckout).WithOne().HasForeignKey(b => b.PedidoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
