using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EFCore.EntityTypeConfigurations
{
    public class TypeProductConfiguration : IEntityTypeConfiguration<TypeProduct>
    {
        public void Configure(EntityTypeBuilder<TypeProduct> builder)
        {
            builder.ToTable("TypeProducts");

            builder.HasKey(tp => tp.TypeProductId);

            builder.Property(tp => tp.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(tp => tp.Products)
                .WithOne(p => p.TypeProduct)
                .HasForeignKey(p => p.TypeProductId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
