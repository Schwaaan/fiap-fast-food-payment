using FourSix.Domain.Entities;
using FourSix.Domain.Entities.ClienteAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourSix.Infrastructure.DataAccess.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {

        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Cliente");
            builder.HasKey(e => e.Id);
            builder.Property(b => b.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            
            builder.Property(b => b.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.Email)
            .IsRequired()
            .HasMaxLength(100)
            .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);



        }
    }
}
