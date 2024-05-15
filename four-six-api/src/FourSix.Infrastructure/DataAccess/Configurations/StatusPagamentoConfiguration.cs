using FourSix.Domain.Entities.PagamentoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourSix.Infrastructure.DataAccess.Configurations
{
    public class StatusPagamentoConfiguration : IEntityTypeConfiguration<StatusPagamento>
    {

        public void Configure(EntityTypeBuilder<StatusPagamento> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("StatusPagamento");
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
