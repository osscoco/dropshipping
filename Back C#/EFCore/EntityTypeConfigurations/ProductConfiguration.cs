using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EFCore.EntityTypeConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.Label)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Reference)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .HasMaxLength(1000);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Quantity)
                .IsRequired();

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(255);

            builder.HasOne(p => p.TypeProduct)
                .WithMany(tp => tp.Products)
                .HasForeignKey(p => p.TypeProductId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.OrderProducts)
                .WithOne(op => op.Product)
                .HasForeignKey(op => op.ProductId);
        }
    }
}
