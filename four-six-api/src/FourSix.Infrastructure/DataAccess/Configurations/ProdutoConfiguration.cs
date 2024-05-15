using FourSix.Domain.Entities.ProdutoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourSix.Infrastructure.DataAccess.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Produto");
            builder.HasKey(e => e.Id);
            builder.Property(b => b.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.Descricao)
                .HasMaxLength(200)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.Categoria)
                .IsRequired()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.Preco)
                .IsRequired()
                .HasPrecision(6, 2)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.Ativo)
               .IsRequired()
               .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
        }
    }
}
