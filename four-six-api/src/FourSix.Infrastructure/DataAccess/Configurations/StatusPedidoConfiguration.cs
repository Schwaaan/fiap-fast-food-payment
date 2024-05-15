using FourSix.Domain.Entities.PedidoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourSix.Infrastructure.DataAccess.Configurations
{
    public class StatusPedidoConfiguration : IEntityTypeConfiguration<StatusPedido>
    {

        public void Configure(EntityTypeBuilder<StatusPedido> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("StatusPedido");
            builder.HasKey(e => e.Id);

            builder.Property(b => b.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasConversion<short>()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.Descricao)
                .IsRequired()
                .HasMaxLength(20)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
        }
    }
}
